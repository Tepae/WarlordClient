Imports WarlordClient.GameEngine
Imports WarlordClient.Graphics
Imports WarlordClient.Graphics.CardGrid
Imports WarlordClient.GameEngine.CharacterMovement

Public Class CardGrid

#Region "members"

    Private _display As Display
    Private _drawnCards As New List(Of SmallCard)
    Private _drawnCardCollection As CardCollection
    Private _owner As Guid = Guid.Empty
    Private _callbackForPlacementDot As Action(Of SmallCard, PlacementChoice)
    Private _idToSmallCardCache As New Dictionary(Of Guid, SmallCard)
    Private _placementDots As New List(Of PlacementDot)
    Private Const TopOffset As Integer = 50
    Private Const LeftOffset As Integer = 50
    Private Const SpaceBetweenRanks As Integer = 20
    Private Const SpaceBetweenCards As Integer = 30
    Private Const PlacementDotXOffset As Integer = 15
    Private Const PlacementDotYOffset As Integer = 15
    Private Const SmallCardDimension As Integer = 105

    Public Event MouseHoverOnCard(sender As Object, e As Graphics.CardGrid.CardGridEventArgs)
    Public Event MouseClickOnCard(sender As Object, e As Graphics.CardGrid.CardGridClickEventArgs)

#End Region

#Region "methods"

    Public Sub DrawCards(cc As CardCollection)
        _idToSmallCardCache.Clear()
        Select Case DisplayStyle
            Case Display.HighestTopmost
                DrawCardsHighestTopMost(cc)
            Case Display.LowestTopmost
                DrawCardsLowestTopMost(cc)
        End Select
    End Sub

    Public Sub SetLabel(txt As String)
        Me.lblOwnerTop.Text = txt
        Me.lblOwnerBottom.Text = txt
    End Sub

    Private Sub DrawCardsHighestTopMost(cc As CardCollection)
        ClearAllDrawnCards()
        _drawnCardCollection = cc
        Dim sc As SmallCard = Nothing
        Dim x As Integer = LeftOffset
        Dim y As Integer = Me.Height - TopOffset
        For rank As Integer = 1 To cc.RankCount
            y -= Constants.SmallCardHeight
            For Each card As CardInstance In cc.CharactersInRank(rank)
                sc = CreateSmallCard(x, y, card)
                x += sc.Size.Width
                x += SpaceBetweenCards
                For Each attachment In card.Attachments
                    CreateAttachementForCard(sc, attachment)
                Next
            Next
            x = LeftOffset
            y -= SpaceBetweenRanks
        Next
    End Sub

    Private Sub DrawCardsLowestTopMost(cc As CardCollection)
        ClearAllDrawnCards()
        _drawnCardCollection = cc
        Dim sc As SmallCard = Nothing
        Dim x As Integer = LeftOffset
        Dim y As Integer = TopOffset
        For rank As Integer = 1 To cc.RankCount
            For Each card As CardInstance In cc.CharactersInRank(rank)
                sc = CreateSmallCard(x, y, card)
                x += sc.Size.Width
                x += SpaceBetweenCards
                For Each attachment In card.Attachments
                    CreateAttachementForCard(sc, attachment)
                Next
            Next
            x = LeftOffset
            y += Constants.SmallCardHeight
            y += SpaceBetweenRanks
        Next
    End Sub

    Private Function CreateSmallCard(x As Integer, y As Integer, c As CardInstance) As SmallCard
        Dim sc As New SmallCard(c)
        sc.Location = New Point(x, y)
        Me.Controls.Add(sc)
        _drawnCards.Add(sc)
        _idToSmallCardCache.Add(c.Id, sc)
        SetAnchoring(sc)
        AddHandler sc.MouseHoverOverMe, AddressOf RaiseMouseHoverEvent
        AddHandler sc.MouseClickOnMe, AddressOf RaiseMouseClickEvent
        AddHandler sc.CardInstanceHasChanged, AddressOf HandleCardInstanceChanged
        sc.Show()
        Return sc
    End Function

    Private Sub CreateAttachementForCard(c As SmallCard, attachment As CardInstance)

    End Sub

    Private Sub SetAnchoring(sc As SmallCard)
        If DisplayStyle = Display.LowestTopmost Then
            sc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        ElseIf DisplayStyle = Display.HighestTopmost Then
            sc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        End If
    End Sub

    Private Sub SetAnchoring(pd As PlacementDot)
        If DisplayStyle = Display.LowestTopmost Then
            pd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        ElseIf DisplayStyle = Display.HighestTopmost Then
            pd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        End If
    End Sub

    Private Sub ClearAllDrawnCards()
        For Each sc As SmallCard In _drawnCards
            RemoveHandler sc.MouseHoverOverMe, AddressOf RaiseMouseHoverEvent
            RemoveHandler sc.MouseClickOnMe, AddressOf RaiseMouseClickEvent
            RemoveHandler sc.CardInstanceHasChanged, AddressOf HandleCardInstanceChanged
            sc.Hide()
            sc.Dispose()
        Next
        _drawnCards.Clear()
    End Sub

    Private Sub RaiseMouseHoverEvent(sender As Object, e As EventArgs)
        Dim kvp As KeyValuePair(Of Integer, Integer) = _drawnCardCollection.RankAndPlaceOfCharacter(DirectCast(sender, SmallCard).Card)
        Dim args As New CardGridEventArgs(kvp.Key, kvp.Value, _drawnCardCollection.Owner)
        RaiseEvent MouseHoverOnCard(sender, args)
    End Sub

    Private Sub RaiseMouseClickEvent(sender As Object, e As MouseEventArgs)
        Dim kvp As KeyValuePair(Of Integer, Integer) = _drawnCardCollection.RankAndPlaceOfCharacter(DirectCast(sender, SmallCard).Card)
        Dim args As New CardGridClickEventArgs(kvp.Key, kvp.Value, _drawnCardCollection.Owner, e)
        RaiseEvent MouseClickOnCard(sender, args)
    End Sub

    Public Sub DrawPlacementDots(sc As SmallCard, mcs As List(Of CharacterMovement.PlacementChoice), callback As Action(Of SmallCard, PlacementChoice))
        _callbackForPlacementDot = callback
        For Each mc As PlacementChoice In mcs
            DrawPlacementDot(sc, mc)
        Next
    End Sub

    Private Sub DrawPlacementDot(sc As SmallCard, mc As PlacementChoice)
        Dim smallCards As Tuple(Of SmallCard, SmallCard) = FindSmallCardsToDrawDotInBetween(mc)
        Dim x As Integer = GetXForPlacementDot(smallCards)
        Dim y As Integer = GetYForPlacementDot(sc, smallCards)
        DrawPlacementDot(x, y, sc, mc)
    End Sub

    Private Function GetXForPlacementDot(smallcards As Tuple(Of SmallCard, SmallCard)) As Integer
        Dim ret As Integer
        If smallcards.Item1 Is Nothing AndAlso smallcards.Item2 Is Nothing Then
            ret = LeftOffset
        ElseIf smallcards.Item1 Is Nothing Then
            ret = smallcards.Item2.Location.X - PlacementDotXOffset
        Else
            ret = smallcards.Item1.Location.X + SmallCardDimension + PlacementDotXOffset
        End If
        Return ret
    End Function

    Private Function GetYForPlacementDot(sc As SmallCard, smallcards As Tuple(Of SmallCard, SmallCard)) As Integer
        Dim ret As Integer
        If smallcards.Item1 Is Nothing AndAlso smallcards.Item2 Is Nothing Then
            Select Case DisplayStyle
                Case Display.HighestTopmost
                    ret = sc.Location.Y + SmallCardDimension + SpaceBetweenRanks
                Case Display.LowestTopmost
                    ret = sc.Location.Y - SmallCardDimension - SpaceBetweenRanks
            End Select
        Else
            Select Case DisplayStyle
                Case Display.HighestTopmost
                    ret = If(smallcards.Item1 Is Nothing, smallcards.Item2.Location.Y, smallcards.Item1.Location.Y) - PlacementDotYOffset
                Case Display.LowestTopmost
                    ret = If(smallcards.Item1 Is Nothing, smallcards.Item2.Location.Y, smallcards.Item1.Location.Y) + PlacementDotYOffset
            End Select
        End If
        Return ret
    End Function

    Private Sub DrawPlacementDot(x As Integer, y As Integer, sc As SmallCard, mc As PlacementChoice)
        Dim pa As New PlacementDot()
        pa.Smallcard = sc
        pa.MovementChoice = mc
        pa.Location = New Point(x, y)
        _placementDots.Add(pa)
        Me.Controls.Add(pa)
        SetAnchoring(pa)
        AddHandler pa.DotClicked, AddressOf HandlePlacementDotClicked
        pa.Show()
    End Sub

    Private Function FindSmallCardsToDrawDotInBetween(mc As PlacementChoice) As Tuple(Of SmallCard, SmallCard)
        Dim left As SmallCard = If(_idToSmallCardCache.ContainsKey(If(mc.Left Is Nothing, Guid.Empty, mc.Left.Id)), _idToSmallCardCache(mc.Left.Id), Nothing)
        Dim right As SmallCard = If(_idToSmallCardCache.ContainsKey(If(mc.Right Is Nothing, Guid.Empty, mc.Right.Id)), _idToSmallCardCache(mc.Right.Id), Nothing)
        Return New Tuple(Of SmallCard, SmallCard)(left, right)
    End Function

    Public Sub ClearAllDrawnDots()
        For Each dot As PlacementDot In _placementDots
            RemoveHandler dot.DotClicked, AddressOf HandlePlacementDotClicked
            dot.Hide()
            dot.Dispose()
            dot = Nothing
        Next
        _placementDots.Clear()
    End Sub

    Private Sub HandlePlacementDotClicked(sender As Object, e As EventArgs)
        Dim dot As PlacementDot = DirectCast(sender, PlacementDot)
        _callbackForPlacementDot.Invoke(dot.Smallcard, dot.MovementChoice)
    End Sub

    Private Sub HandleCardInstanceChanged(sender As Object)
        RefreshDrawnCards()
    End Sub

    Private Sub RefreshDrawnCards()
        DrawCards(_drawnCardCollection)
    End Sub

#End Region

#Region "eventhandlers"

    Private Sub CardGrid_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If Not _drawnCardCollection Is Nothing Then
            DrawCards(_drawnCardCollection)
        End If
    End Sub

#End Region

#Region "properties"

    Public Property DisplayStyle As Display
        Get
            Return _display
        End Get
        Set(value As Display)
            _display = value
        End Set
    End Property

    Public Property Owner As Guid
        Get
            Return _owner
        End Get
        Set(value As Guid)
            _owner = value
        End Set
    End Property

#End Region

#Region "enums"

    Public Enum Display
        HighestTopmost
        LowestTopmost
    End Enum

#End Region

End Class

