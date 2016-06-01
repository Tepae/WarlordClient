Imports WarlordClient.GameEngine.EventNotifier
Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CostAndEffect.Effect

    Public Class MoveCharacterEffect
        Implements IEffect
        Implements IListener

        Private _range As Integer
        Private _performed As Boolean
        Private _id As Guid
        Public Event EffectPerformed(effect As IEffect) Implements IEffect.EffectPerformed

        Public Sub New(range As Integer)
            _range = range
            _performed = False
        End Sub

        Public Sub Perform(id As Guid, sc As SmallCard, ge As GameEngine, passTurn As Boolean) Implements IEffect.Perform
            _id = id
            Dim cm As New CharacterMover(id, ge, CharacterPlacementDialogFactory.CreateDialogForStandardMovement(ge, sc, ge.CardCollectionOfCardInstance(sc.Card), _range), passTurn)
            cm.MoveCharacter()
        End Sub

        Public Sub Notify(id As Guid, hasData As Boolean) Implements IListener.Notify
            If _id = id Then
                Performed = True
            End If
        End Sub

        Public Property Performed As Boolean Implements IEffect.Performed
            Get
                Return _performed
            End Get
            Set(value As Boolean)
                _performed = value
                RaiseEvent EffectPerformed(Me)
            End Set
        End Property


    End Class

End Namespace