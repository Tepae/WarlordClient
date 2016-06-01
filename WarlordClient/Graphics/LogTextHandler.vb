Namespace Graphics

    Public Class LogTextHandler

        Private _rtxtBox As RichTextBox

        Public Sub New(rtxtBox As RichTextBox)
            _rtxtBox = rtxtBox
        End Sub

        Private Function GetTimePrefix() As String
            Return "[" & Date.Now.ToShortTimeString() & "] "
        End Function

        Private Sub AppendTimeToLogBox()
            Dim time As String = GetTimePrefix()
            AppendTextToLogBox(time, Color.Red, FontStyle.Bold)
        End Sub

        Private Sub AppendPlayerNameToLogBox(playerName As String)
            playerName = playerName & ": "
            AppendTextToLogBox(playerName, Color.MediumAquamarine, FontStyle.Bold)
        End Sub

        Public Sub AppendPlayerInputToLogBox(txt As String, playerName As String)
            AppendTimeToLogBox()
            AppendPlayerNameToLogBox(playerName)
            AppendTextToLogBox(txt & ControlChars.NewLine, Color.Black, FontStyle.Regular)
            _rtxtBox.ScrollToCaret()
            _rtxtBox.Select(0, 0)
        End Sub

        Public Sub AppendSystemMessageToLogBox(txt As String)
            AppendPlayerInputToLogBox(txt, Constants.SystemName)
        End Sub

        Private Sub AppendTextToLogBox(txt As String, c As Color, fs As FontStyle)
            Dim startPos As Integer = Len(_rtxtBox.Text)
            _rtxtBox.AppendText(txt)
            _rtxtBox.Select(startPos, txt.Length)
            _rtxtBox.SelectionFont = New Font(_rtxtBox.Font, fs)
            _rtxtBox.SelectionColor = c
        End Sub

    End Class

End Namespace