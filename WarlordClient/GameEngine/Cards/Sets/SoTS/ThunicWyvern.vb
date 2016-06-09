Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class ThunicWyvern
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            _name = "Thunic Wyvern"
            _imagePath = "\images\SotS\thunicwyvern.jpg"
            _level = 2
            _classes.Add(ClassEnum.None)
            'WlCharacter
            Races.Add(RaceEnum.Mercenary)
            ArmorClass = 13
            Skill = 1
            _hitPoints = 1
            Alignment = AlignmentEnum.Evil
            Traits.Add(CharacterTraitEnum.Monster)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(3))
        End Function

        Public Overrides Function GetOtherActions() As List(Of PerformableAction)
            Return New List(Of PerformableAction) From {New PerformableAction("Move (once per turn)", New List(Of ICost) From {New OncePerTurn("Move")}, New List(Of IEffect) From {New MoveCharacterEffect(1, True)})}
        End Function

    End Class

End Namespace