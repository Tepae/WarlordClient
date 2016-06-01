Imports WarlordClient.Setup
Imports WarlordClient.PrebuiltDeck
Imports WarlordClient.GameEngine
Imports WarlordClient.GameEngine.Card
Imports System.IO
Imports WarlordClient.Graphics.CardGrid

Public Class SetupGameForm

    Private _callBack As DeckSelected
    Private _cic As CardInstanceCreator
    Private _cardCollection As CardCollection
    Private _deck As Deck
    Private _deckList As Decklist
    Private _wl As Warlord
    Private _clickedSmallCard As SmallCard = Nothing
    Private WithEvents _cpbdf As ChoosePreBuiltDeckForm

    Public Delegate Sub DeckSelected(ByVal playerName As String, ByVal deck As Setup.Decklist, ByVal startingCharacters As CardCollection)

    Public Sub New(callBack As DeckSelected)
        InitializeComponent()
        ConsoleManager.Write("Creating SetupGameForm", True)
        _callBack = callBack
        _cardCollection = New CardCollection(Nothing)
    End Sub

#Region "methods"

    Private Function LoadDeck(path As String) As List(Of String)
        Dim reader As StreamReader = New StreamReader(path)
        Dim line As String
        Dim cards As New List(Of String)
        Do While reader.Peek() <> -1
            line = reader.ReadLine()
            If Not LineIsCommentOrWhiteSpace(line) Then
                cards.Add(line)
            End If
        Loop
        Return cards
    End Function

    Private Function LineIsCommentOrWhiteSpace(line As String) As Boolean
        Return String.IsNullOrWhiteSpace(line) OrElse line.StartsWith("//")
    End Function

    Private Sub SetRandomPlayerName()
        Dim randomName As String = "Player_" + (New Random).Next(9999).ToString
        txtPlayerName.Text = randomName
    End Sub

    Private Sub UpdateFullcard(c As Card)
        fullCard.UpdateImage(c)
    End Sub

    Private Sub Submit()
        ConsoleManager.Write(String.Format("Player {0} submits deck {1}", txtPlayerName.Text, _deckList.DeckName), True)
        _callBack(txtPlayerName.Text, _deckList, _cardCollection)
        Me.Close()
        Me.Dispose()
    End Sub

#Region "choose deck"

    Private Sub NewDeckChosenFromInternalDialog(deck As PrebuiltDeck.Deck)
        Dim cardNamesAndAmounts As New List(Of String)
        For Each card As String In deck.GetCardNames()
            Dim cardNameAndAmount As String = deck.GetAmountOfCard(card) & " " & card
            cardNamesAndAmounts.Add(cardNameAndAmount)
        Next
        _deck = deck
        CreateDecklist(deck.Name, cardNamesAndAmounts)
        NewDeckChosen()
    End Sub

    Private Sub CreateDecklist(deckName As String, cards As List(Of String))
        _deckList = New Decklist(deckName.Split("\").Last)
        For Each card As String In cards
            Dim amount As Integer = -1
            Dim cardname As String = String.Empty
            Integer.TryParse(card.Split(" "c)(0), amount)
            cardname = GetCardName(card)
            If amount > -1 AndAlso Not String.IsNullOrEmpty(cardname) Then
                _deckList.AddCard(CardinstanceCreator.GetCardFromClassName(cardname), amount)
            End If
        Next
    End Sub

    Private Function GetCardName(row As String) As String
        Dim words As List(Of String) = row.Split(" "c).ToList()
        words.RemoveAt(0)
        Return String.Join(" ", words)
    End Function

    Private Sub NewDeckChosen()
        DisplayDecklistInListbox()
        SetupWarlordComboBox()
    End Sub

    Private Sub DisplayDecklistInListbox()
        lBoxDeck.Items.Clear()
        For Each dle As DeckListEntry In _deckList.Cards
            lBoxDeck.Items.Add(dle)
        Next
    End Sub

    Private Sub SetupWarlordComboBox()
        cbWarlord.Items.Clear()
        For Each dle As DeckListEntry In _deckList.Cards
            If TypeOf dle.Card Is Warlord Then
                cbWarlord.Items.Add(dle.Card)
            End If
        Next
        If cbWarlord.Items.Count = 1 Then
            cbWarlord.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadPredefinedStartingCharacters()
        If _deck IsNot Nothing AndAlso _deck.PredefinedStartingCharacters.Keys.Contains(_wl.Name) Then
            For Each rank As Integer In _deck.PredefinedStartingCharacters(_wl.Name).Keys
                Dim place As Integer = 0
                For Each characterName As String In _deck.PredefinedStartingCharacters(_wl.Name)(rank)
                    Dim ci As CardInstance = _cic.GetCardInstanceFromClassName(characterName)
                    If _cardCollection.HasACharacterAt(rank, place) Then
                        _cardCollection.Replace(ci, rank, place)
                    Else
                        _cardCollection.AddCharacterToRankInPlace(ci, rank, place)
                    End If
                    place += 1
                Next
            Next
        End If
    End Sub

    Private Sub SetupCharacterChoice(wl As Warlord)
        _wl = wl
        CreateDummies(wl)
        AddCurrentWarlordToCardCollection(wl)
        LoadPredefinedStartingCharacters()
        Me.grid.DrawCards(_cardCollection)
        CheckSubmitButtonState()
    End Sub

    Private Sub AddCurrentWarlordToCardCollection(wl As Warlord)
        _cardCollection.AddCharacterToRank(_cic.GetCardInstanceFromClassName(wl.Name), wl.StartsInRankAsWarlord)
    End Sub

    Private Function GetPossibleCharactersForRank(rank As Integer) As List(Of Card)
        Dim ret As New List(Of Card)
        For Each dle As DeckListEntry In _deckList.Cards
            If dle.Card.CardType = Card.CardTypeEnum.Character Then
                If _wl.CharacterCanStartInMyArmy(DirectCast(dle.Card, Character)) Then
                    ret.Add(dle.Card)
                End If
            End If
        Next
        Return ret
    End Function

    Private Sub CheckSubmitButtonState()
        btnSubmit.Enabled = Not _cardCollection.ContainsDummies
    End Sub

    Private Sub CharacterChosenForPlace(sender As Object, e As ToolStripItemClickedEventArgs)
        Dim ci As CardInstance = _cic.GetCardInstanceFromClassName(e.ClickedItem.ToString)
        _cardCollection.Replace(_clickedSmallCard.Card, ci)
        grid.DrawCards(_cardCollection)
        CheckSubmitButtonState()
    End Sub

#End Region

#Region "CardGrid"

    Private Sub UserClicksOnCardInCardGrid(card As SmallCard, e As CardGridClickEventArgs)
        _clickedSmallCard = card
        If e.MouseArgs.Button = Windows.Forms.MouseButtons.Right Then
            ShowContextMenuForCharacterChoice(card, e)
        End If
    End Sub

    Private Sub ShowContextMenuForCharacterChoice(card As SmallCard, e As CardGridClickEventArgs)
        Dim listOfUniqueCharactersEliglibleForThisPlace As List(Of Card) = (New CharacterForStartingRankDeterminer).GetListOfUniqueCharactersEliglibleForThisPlace(_deckList, _wl, e.CardIsInRank, _cardCollection)
        If listOfUniqueCharactersEliglibleForThisPlace.Count > 0 Then
            Dim cm As New ContextMenuStrip()
            cm.Items.Add("Add character").Enabled = False
            For Each c As Card In listOfUniqueCharactersEliglibleForThisPlace
                Dim item As ToolStripItem = cm.Items.Add(c.Name)
            Next
            AddHandler cm.ItemClicked, AddressOf CharacterChosenForPlace
            AddHandler cm.Closed, AddressOf TearDownContextMenuEventhandlers
            cm.Show(card, New Point(e.MouseArgs.X, e.MouseArgs.Y))
        End If
    End Sub

    Private Sub TearDownContextMenuEventhandlers(sender As Object, e As ToolStripDropDownClosedEventArgs)
        Dim cm As ContextMenuStrip = DirectCast(sender, ContextMenuStrip)
        RemoveHandler cm.ItemClicked, AddressOf CharacterChosenForPlace
        RemoveHandler cm.Closed, AddressOf TearDownContextMenuEventhandlers
    End Sub

    Private Sub CreateDummies(wl As Warlord)
        Dim startingRanks As List(Of StartingRank) = wl.StartingRanks
        Dim lastProcessedRank As Integer = 0
        _cardCollection.Clear()
        While lastProcessedRank < startingRanks.Count
            Dim rank As StartingRank = GetLowestRankGreaterThan(lastProcessedRank, startingRanks)
            For i As Integer = 1 To rank.NumberOfCharacters
                Dim dummy As CardInstance = _cic.GetCardInstanceFromClassName("DummyCharacter")
                _cardCollection.AddCharacterToRank(dummy, rank.Rank)
            Next
            lastProcessedRank = rank.Rank
        End While
    End Sub

    Private Function GetLowestRankGreaterThan(rankNumber As Integer, ranks As List(Of StartingRank))
        Dim ret As StartingRank = Nothing
        For Each sr As StartingRank In ranks
            If rankNumber < sr.Rank Then
                If ret Is Nothing OrElse sr.Rank < ret.Rank Then
                    ret = sr
                End If
            End If
        Next
        Return ret
    End Function

#End Region

#End Region

#Region "eventhandlers"

    Private Sub SetupGameForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SetRandomPlayerName()
        grid.SetLabel(String.Empty)
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        Submit()
    End Sub

    Private Sub btnLoadDeck_Click(sender As Object, e As EventArgs) Handles btnLoadDeckExternal.Click
        Me.openDeck.ShowDialog()
    End Sub

    Private Sub deck_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lBoxDeck.SelectedIndexChanged
        Dim dle As DeckListEntry = DirectCast(lBoxDeck.SelectedItem, DeckListEntry)
        UpdateFullcard(dle.Card)
    End Sub

    Private Sub btnLoadDeckInternal_Click(sender As Object, e As EventArgs) Handles btnLoadDeckInternal.Click
        If _cpbdf IsNot Nothing Then
            _cpbdf.Close()
            _cpbdf.Dispose()
            _cpbdf = Nothing
        End If
        _cpbdf = New ChoosePreBuiltDeckForm()
        _cpbdf.Show()
    End Sub

    Private Sub _cpbdf_DeckSelected(dck As PrebuiltDeck.Deck) Handles _cpbdf.DeckSelected
        NewDeckChosenFromInternalDialog(dck)
    End Sub

    Private Sub cbWarlord_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbWarlord.SelectedValueChanged
        SetupCharacterChoice(DirectCast(cbWarlord.SelectedItem, Warlord))
    End Sub

    Private Sub grid_MouseClickOnCard(sender As Object, e As CardGridClickEventArgs) Handles grid.MouseClickOnCard
        UserClicksOnCardInCardGrid(DirectCast(sender, SmallCard), e)
    End Sub

    Private Sub grid_MouseHoverOnCard(sender As Object, e As CardGridEventArgs) Handles grid.MouseHoverOnCard
        UpdateFullcard(DirectCast(sender, SmallCard).Card.Card)
    End Sub

#End Region

#Region "properties"

    Private ReadOnly Property CardinstanceCreator As CardInstanceCreator
        Get
            If _cic Is Nothing Then
                _cic = New CardInstanceCreator
            End If
            Return _cic
        End Get
    End Property

#End Region

End Class