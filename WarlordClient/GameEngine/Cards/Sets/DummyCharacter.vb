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
            Me.Races.Add(RaceEnum.Any)
            Me.ArmorClass = 1
            Me.Skill = 0
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Evil

        End Sub

        Public Overrides Function IsDummy() As Boolean
            Return True
        End Function

    End Class

End Namespace