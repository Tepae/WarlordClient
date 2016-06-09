Imports System.Reflection

Namespace GameEngine

    Public Class CardInstanceCreator

        Private _cnm As CardNameMapper

        Public Sub New()
            _cnm = New CardNameMapper
        End Sub

        Public Function GetCardFromClassName(name As String) As Cards.Card.Card
            name = _cnm.GetMappedCardname(name)
            name = TrimCardName(name)
            Dim t As Type = GetAssembly().GetType(String.Format("WarlordClient.GameEngine.{0}", TrimCardName(name)))
            Dim c As Cards.Card.Card = Activator.CreateInstance(t)
            Return c
        End Function

        Public Function GetCardInstanceFromClassName(name As String) As CardInstance
            Return New CardInstance(GetCardFromClassName(name))
        End Function

        Private Function GetAssembly() As [Assembly]
            Return Assembly.GetExecutingAssembly()
        End Function

        Private Function TrimCardName(name As String) As String
            Dim charsToTrim As Char() = New Char() {"-", "'", "!", " "}
            Return charsToTrim.Aggregate(name, Function(current, c) current.Replace(c, String.Empty))
        End Function

    End Class

End Namespace
