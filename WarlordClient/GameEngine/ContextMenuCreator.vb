Imports WarlordClient.GameEngine.Card
Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect

Namespace GameEngine

    Public Class ContextMenuCreator

        Private ReadOnly _gs As GameState
        Private ReadOnly _ge As GameEngine
        Private _sc As SmallCard

        Public Sub New(gs As GameState, ge As GameEngine)
            _gs = gs
            _ge = ge
        End Sub

        Public Sub CreateContextMenu(sc As SmallCard, x As Integer, y As Integer)
            _sc = sc
            Dim cm As New ContextMenuStrip
            For Each pa As PerformableAction In sc.Card.Card.GetPerformableActions
                Dim item = New PerformableActionToolStripMenuItem(pa)
                cm.Items.Add(item)
            Next
            SetEventHandlers(cm)
            cm.Show(sc, x, y)
        End Sub

        Private Sub SetEventHandlers(cm As ContextMenuStrip)
            AddHandler cm.ItemClicked, AddressOf ItemClicked
            AddHandler cm.Closed, AddressOf TearDownEventHandlers
        End Sub

        Private Sub ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
            Dim cmep As New CostManagerEffectPerformer(_gs, _ge)
            cmep.PayCostsToGetEffects(DirectCast(e.ClickedItem, PerformableActionToolStripMenuItem).Action, _sc)
        End Sub

        Private Sub TearDownEventHandlers(sender As Object, e As EventArgs)
            Dim cm = DirectCast(sender, ContextMenuStrip)
            RemoveHandler cm.ItemClicked, AddressOf ItemClicked
            RemoveHandler cm.Closed, AddressOf TearDownEventHandlers
        End Sub

    End Class

End Namespace