Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.Cost.CostAndEffect
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
            Me._races.Add(Race.Elf)
            Me._armorClass = 16
            Me._skill = 8
            Me._hitPoints = 3
            Me._alignment = Alignment.Evil
            Me._traits.Add(CharacterTrait.Unique)
            Me._traits.Add(CharacterTrait.Warlord)
        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(7), New Strike.MeleeStrike(2))
        End Function

        Public Overrides Function GetOtherActions() As List(Of Card.PerformableAction)
            Return New List(Of Card.PerformableAction) From {New Card.PerformableAction("Discard card to move", False, AddressOf DiscardToMove)}
        End Function

        Private Sub DiscardToMove(sc As SmallCard, ge As GameEngine)
            Dim caea As New CostAndEffectAction(sc, _
                                                ge, _
                                                New List(Of ICost) From {New DiscardCards(1, ge)}, _
                                                New List(Of IEffect) From {New MoveCharacterEffect(1)})
            caea.PayCostsToGetEffects()
        End Sub

    End Class

End Namespace