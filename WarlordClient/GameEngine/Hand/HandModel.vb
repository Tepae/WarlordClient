Namespace GameEngine.Hand

    Public Class HandModel

        Private ReadOnly _cards As List(Of CardInstance)

        Public Event CardListChanged(doRedraw As Boolean)

        Public Sub New(owner As Guid)
            Me.Owner = owner
            _cards = New List(Of CardInstance)
        End Sub

        Public Sub AddCards(cis As List(Of CardInstance))
            For Each ci As CardInstance In cis
                AddCard(ci, False)
            Next
            RaiseEvent CardListChanged(True)
        End Sub

        Public Sub SetCards(cis As List(Of CardInstance))
            _cards.Clear()
            AddCards(cis)
        End Sub

        Public Sub RemoveCard(ci As CardInstance, doRedraw As Boolean)
            If _cards.Contains(ci) Then
                _cards.Remove(ci)
            End If
            RaiseEvent CardListChanged(doRedraw)
        End Sub

        Private Sub AddCard(ci As CardInstance, doRedraw As Boolean)
            ci.CardLocation = CardInstance.Location.InHand
            _cards.Add(ci)
            RaiseEvent CardListChanged(doRedraw)
        End Sub

        Public Function NumberOfCardsInHand() As Integer
            Return _cards.Count
        End Function

        Public Function Cards() As List(Of CardInstance)
            Return _cards.ToList()
        End Function

        Public ReadOnly Property Owner As Guid

    End Class

End Namespace