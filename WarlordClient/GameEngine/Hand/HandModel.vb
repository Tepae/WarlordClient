Namespace GameEngine.Hand

    Public Class HandModel

        Private _cards As List(Of CardInstance)
        Private _owner As Guid

        Public Event CardListChanged(doRedraw As Boolean)

        Public Sub New(owner As Guid)
            _owner = owner
            _cards = New List(Of CardInstance)
        End Sub

        Public Sub AddCard(ci As CardInstance, doRedraw As Boolean)
            ci.CardLocation = CardInstance.Location.InHand
            _cards.Add(ci)
            RaiseEvent CardListChanged(doRedraw)
        End Sub

        Public Sub AddCards(cis As List(Of CardInstance))
            For Each ci As CardInstance In cis
                AddCard(ci, False)
            Next
            RaiseEvent CardListChanged(True)
        End Sub

        Public Sub RemoveCard(ci As CardInstance, doRedraw As Boolean)
            If _cards.Contains(ci) Then
                _cards.Remove(ci)
            End If
            RaiseEvent CardListChanged(doRedraw)
        End Sub

        Public Property Cards As List(Of CardInstance)
            Get
                Return _cards
            End Get
            Set(value As List(Of CardInstance))
                For Each ci As CardInstance In value
                    ci.CardLocation = CardInstance.Location.InHand
                Next
                _cards = value
                RaiseEvent CardListChanged(True)
            End Set
        End Property

        Public ReadOnly Property Owner As Guid
            Get
                Return _owner
            End Get
        End Property

    End Class

End Namespace