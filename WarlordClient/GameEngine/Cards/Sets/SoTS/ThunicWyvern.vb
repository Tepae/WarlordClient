Imports WarlordClient.GameEngine.Cost.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine

    Public Class ThunicWyvern
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Thunic Wyvern"
            Me._imagePath = "\images\SotS\thunicwyvern.jpg"
            Me._level = 2
            Me._classes.Add([Class].None)
            'character
            Me._races.Add(Race.Mercenary)
            Me._armorClass = 13
            Me._skill = 1
            Me._hitPoints = 1
            Me._alignment = Alignment.Evil
            Me._traits.Add(CharacterTrait.Monster)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(3))
        End Function

        Public Overrides Function GetOtherActions() As List(Of Card.PerformableAction)
            Return New List(Of Card.PerformableAction) From {New Card.PerformableAction("Move as order (once per turn)", False, AddressOf MoveAsOrder)}
        End Function

        Private Sub MoveAsOrder(sc As SmallCard, ge As GameEngine)
            Dim caea As New CostAndEffectAction(sc,
                                                ge,
                                                New List(Of ICost) From {New DiscardCards(1, ge)},
                                                New List(Of IEffect) From {New MoveCharacterEffect(1)})
            caea.PayCostsToGetEffects()
        End Sub

    End Class

End Namespace