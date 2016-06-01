Namespace Graphics

    Public Class PromptTextHandler

        Private ReadOnly _txtBox As TextBox

        Public Sub New(txtBox As TextBox)
            _txtBox = txtBox
        End Sub

        Public Sub Clear()
            _txtBox.Clear()
        End Sub

        Public Sub AppendText(txt As String)
            _txtBox.AppendText(txt)
        End Sub

        Public Sub SetText(txt As String)
            _txtBox.Text = txt
        End Sub

    End Class

End Namespace