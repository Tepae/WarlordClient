Imports WarlordClient.GameEngine.Cards.Card

Namespace Graphics

    Public Class PerformableActionToolStripMenuItem
        Inherits ToolStripMenuItem

        Private ReadOnly _pa As PerformableAction

        Public Sub New(pa As PerformableAction)
            InitializeComponent()
            _pa = pa
            Text = ToString()
        End Sub

        Public Overrides Function ToString() As String
            Return _pa.Description
        End Function

        Public ReadOnly Property Action As PerformableAction
            Get
                Return _pa
            End Get
        End Property

    End Class

End Namespace