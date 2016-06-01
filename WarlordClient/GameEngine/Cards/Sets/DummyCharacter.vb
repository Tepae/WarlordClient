Imports WarlordClient.GameEngine.Card

Namespace GameEngine

    Public Class DummyCharacter
        Inherits Character

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Dummy"
            Me._imagePath = "\images\dummy.jpg"
            Me._level = 1
            Me._classes.Add([Class].Any)
            'character
            Me._races.Add(Race.Any)
            Me._armorClass = 1
            Me._skill = 0
            Me._hitPoints = 1
            Me._alignment = Alignment.Evil

        End Sub

        Public Overrides Function IsDummy() As Boolean
            Return True
        End Function

    End Class

End Namespace