Imports WarlordClient.GameEngine.Card

Namespace GameEngine

    Public Class ContextMenuCreator

        Private _sc As SmallCard

        Public Sub CreateContextMenu(sc As SmallCard, x As Integer, y As Integer)
            _sc = sc
            Dim cm As New ContextMenuStrip
            For Each pa As PerformableAction In sc.Card.Card.GetPerformableActions
                Dim item As PerformableActionToolStripMenuItem = New PerformableActionToolStripMenuItem(pa)
                If (item.Action.RequiresSpending AndAlso sc.Card.CardState <> CardInstance.State.Ready) OrElse sc.Card.CardState = CardInstance.State.Stunned Then
                    item.Enabled = False
                End If
                cm.Items.Add(item)
            Next
            SetEventHandlers(cm)
            cm.Show(sc, x, y)
        End Sub

        Private Sub SetEventHandlers(cm As ContextMenuStrip)
            AddHandler cm.ItemClicked, AddressOf PerformAction
            AddHandler cm.Closed, AddressOf TearDownEventHandlers
        End Sub

        Private Sub PerformAction(sender As Object, e As ToolStripItemClickedEventArgs)
            ActionPerformer.PerformAction(_sc, DirectCast(e.ClickedItem, PerformableActionToolStripMenuItem).Action)
        End Sub

        Private Sub TearDownEventHandlers(sender As Object, e As EventArgs)
            Dim cm As ContextMenuStrip = DirectCast(sender, ContextMenuStrip)
            RemoveHandler cm.ItemClicked, AddressOf PerformAction
            RemoveHandler cm.Closed, AddressOf TearDownEventHandlers
        End Sub

    End Class

End Namespace