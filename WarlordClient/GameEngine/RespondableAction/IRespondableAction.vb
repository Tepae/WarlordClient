Namespace GameEngine.RespondableAction

    Public Interface IRespondableAction
        Sub MakeChoices()
        Function AllowedBeforeResponses() As List(Of RespondableAction.ResponseTypeEnum)
        Function AllowedAfterResponses() As List(Of RespondableAction.ResponseTypeEnum)
        Sub Perform(owner As Guid, gs As GameState)
        Function Id() As Guid
    End Interface

End Namespace