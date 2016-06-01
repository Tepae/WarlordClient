Namespace PrebuiltDeck

    Public Class ElvishRogues
        Inherits Deck

        Public Sub New()
            Initialize()
        End Sub

        Friend Overrides Sub Initialize()
            Me._name = "Elvish rogues"
            Me._description = "A rogue deck"

            'Warlord
            Cards.Add("Rathe", 1)

            'Characters
            Cards.Add("Jigoral", 3)
            Cards.Add("Artheon", 3)
            Cards.Add("Whispershot", 3)
            Cards.Add("Brine Fiend", 3)
            Cards.Add("Gueniveure", 3)
            Cards.Add("Kether", 3)
            Cards.Add("Keridwen", 3)

            'Actions
            Cards.Add("Throw", 3)
            Cards.Add("Sand in Your Eyes", 3)
            Cards.Add("Meet at the inn!", 3)

            'Items
            'Cards.Add("Dagger", 3)

            PredefinedStartingCharacters.Add("Rathe", New Dictionary(Of Integer, List(Of String)))
            PredefinedStartingCharacters("Rathe").Add(1, New List(Of String)(New String() {"Jigoral", "Jigoral", "Jigoral"}))
            PredefinedStartingCharacters("Rathe").Add(2, New List(Of String)(New String() {"Artheon", "Artheon"}))
            PredefinedStartingCharacters("Rathe").Add(3, New List(Of String)(New String() {"Rathe"}))
        End Sub

    End Class

End Namespace
