Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class Rathe
        Inherits Warlord

        Public Sub New()
            MyBase.New()

            'card
            _name = "Rathe"
            _imagePath = "\images\SotS\rathe.jpg"
            _level = 5
            _classes.Add(ClassEnum.Rogue)
            'WlCharacter
            Races.Add(RaceEnum.Elf)
            ArmorClass = 16
            Skill = 8
            _hitPoints = 3
            Alignment = AlignmentEnum.Evil
            Traits.Add(CharacterTraitEnum.Unique)
            Traits.Add(CharacterTraitEnum.Warlord)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(7), New Strike.MeleeStrike(2))
        End Function

        Public Overrides Function GetOtherActions() As List(Of PerformableAction)
            Return New List(Of PerformableAction) From {New PerformableAction("Discard card to move", New List(Of ICost) From {New DiscardCards(1)}, New List(Of IEffect) From {New MoveCharacterEffect(1, True)})}
        End Function

    End Class

End Namespace