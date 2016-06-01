Imports WarlordClient.GameEngine.Card
Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.Order

    Public Class PlayCharacter
        Inherits PlayCard
        Implements IOrder

        Private ReadOnly _gameState As GameState
        Private ReadOnly _placementChoice As PlacementChoice

        Public Sub New(id As Guid, owner As Guid, gameState As GameState, ci As CardInstance, pc As PlacementChoice, passTurn As Boolean)
            MyBase.New(id, owner, ci, passTurn)
            _gameState = gameState
            _placementChoice = pc
        End Sub

        Public Sub HandleAfterReacts() Implements IOrder.HandleAfterReacts

        End Sub

        Public Sub HandleBeforeReacts() Implements IOrder.HandleBeforeReacts

        End Sub

        Public Sub Perform(ge As GameEngine) Implements IOrder.Perform
            _gameState.GetHandModelById(Owner).RemoveCard(Ci, True)
            Ci.CardState = DirectCast(Ci.Card, Character).StartingState()
            _gameState.AddCharacterToRankFromPlacementChoice(Owner, Ci, _placementChoice)
            ge.RaiseSystemMessage(String.Format("{0} plays {1}", ge.GetPlayerById(Owner), Ci.Card.Name))
            ge.ClearPlacementDotsFromCardGrid(Owner)
        End Sub

        Public Property PassTurnWhenDone As Boolean Implements IOrder.PassTurnWhenDone
            Get
                Return PassTurn
            End Get
            Set
                PassTurn = Value
            End Set
        End Property

    End Class

End Namespace