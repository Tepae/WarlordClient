Namespace GameEngine.Card

    Public MustInherit Class Action
        Inherits Card

        Friend _traits As New List(Of ActionTrait)

        Public Sub New()
            MyBase.New()
            Me._cardType = CardTypeEnum.Action
            _traits = New List(Of ActionTrait)
        End Sub

#Region "methods"


#End Region

#Region "enums"

        Public Enum ActionTrait
            None
        End Enum

#End Region

    End Class

End Namespace