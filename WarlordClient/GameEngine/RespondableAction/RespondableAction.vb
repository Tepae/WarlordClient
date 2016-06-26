Namespace GameEngine.RespondableAction

    Public MustInherit Class RespondableAction

        Friend RespondableActionId As Guid
        Private _uim As IGameEngineUserInterfaceManipulator

        Public Sub New(respondableActionId As Guid)
            Me.RespondableActionId = respondableActionId
        End Sub

        Friend Sub SystemMessage(message As String)
            UserInterfaceManipulator.RaiseSystemMessage(message)
        End Sub

        Private ReadOnly Property UserInterfaceManipulator As IGameEngineUserInterfaceManipulator
            Get
                If _uim Is Nothing Then
                    _uim = GameEngineObjects.UserInterfaceManipulator
                End If
                Return _uim
            End Get
        End Property

        Public Enum ResponseTypeEnum
            MeleeStrike
            RangedStrike
        End Enum


    End Class

End Namespace