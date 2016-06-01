Namespace PrebuiltDeck

    Public Class BryminsWarriors
        Inherits Deck

        Public Sub New()
            Initialize()
        End Sub

        Friend Overrides Sub Initialize()
            Me._name = "Brymin's Warriors"
            Me._description = "A fighter deck"

            'Warlord
            Cards.Add("Duchess Brymin", 1)

            'Characters
            Cards.Add("Whispershot", 3)
            Cards.Add("Brine Fiend", 3)
            Cards.Add("Valanthe", 3)

            'Actions
        End Sub
    End Class

End Namespace
