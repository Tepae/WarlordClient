Imports WarlordClient.Common

Namespace GameEngine.Hand

    Public Class HandHolder

        Private ReadOnly _hands As List(Of HandModel)

        Public Sub New()
            _hands = New List(Of HandModel)
        End Sub

        Public Sub RegisterHandModel(model As HandModel)
            _hands.Add(model)
        End Sub

        Public Function GetHandModelForOwner(owner As Guid) As HandModel
            Dim ret As HandModel = Nothing
            For Each hand As HandModel In _hands
                If hand.Owner = owner Then
                    ret = hand
                    Exit For
                End If
            Next
            If ret Is Nothing Then
                Throw New ArgumentException(String.Format("Could not find hand registered with id {0}", owner.ToString()))
            End If
            Return ret
        End Function

        Public ReadOnly Property Hands() As List(Of HandModel)
            Get
                Return _hands
            End Get
        End Property

    End Class

End Namespace