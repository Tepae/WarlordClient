Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine

    Public Class Rathe
        Inherits Card.Warlord

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Rathe"
            Me._imagePath = "\images\SotS\rathe.jpg"
            Me._level = 5
            Me._classes.Add([Class].Rogue)
            'character
            Me.Races.Add(RaceEnum.Elf)
            Me.ArmorClass = 16
            Me.Skill = 8
            Me._hitPoints = 3
            Me.Alignment = AlignmentEnum.Evil
            Me.Traits.Add(CharacterTraitEnum.Unique)
            Me.Traits.Add(CharacterTraitEnum.Warlord)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(7), New Strike.MeleeStrike(2))
        End Function

        Public Overrides Function GetOtherActions() As List(Of PerformableAction)
            Return New List(Of PerformableAction) From {New PerformableAction("Discard card to move", New List(Of ICost) From {New DiscardCards(1)}, New List(Of IEffect) From {New MoveCharacter(1)})}
        End Function

    End Class

End Namespace