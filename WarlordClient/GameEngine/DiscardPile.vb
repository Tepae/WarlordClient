Namespace GameEngine

    Public Class DiscardPile

        Private _cards As Stack(Of CardInstance)
        Private _owner As Guid

        Public Sub New(owner As Guid)
            _owner = owner
            _cards = New Stack(Of CardInstance)
        End Sub

        Public Sub AddToDiscardPile(ci As CardInstance)
            ci.CardLocation = CardInstance.Location.InDiscardPile
            _cards.Push(ci)
        End Sub

        Public Sub Clear()
            _cards.Clear()
        End Sub

        Public ReadOnly Property Owner As Guid
            Get
                Return _owner
            End Get
        End Property

        Public ReadOnly Property Cards As List(Of CardInstance)
            Get
                Return _cards.ToList
            End Get
        End Property

    End Class

End Namespace