Namespace GameEngine.Cards.Card

    Public Class StartingRankCharacterDescription

        Public ReadOnly CharacterClassEnum As WlCharacter.ClassEnum = WlCharacter.ClassEnum.Any
        Public ReadOnly CharacterRace As WlCharacter.RaceEnum = WlCharacter.RaceEnum.Any
        Public ReadOnly CharacterLevel As Integer = -1
        Public AdditionalTraits As List(Of WlCharacter.CharacterTraitEnum) = Nothing

        Public Sub New(characterClassEnum As WlCharacter.ClassEnum, characterRace As WlCharacter.RaceEnum, characterLevel As Integer, Optional ByVal addtionalTraits As List(Of WlCharacter.CharacterTraitEnum) = Nothing)
            Me.CharacterClassEnum = characterClassEnum
            Me.CharacterRace = characterRace
            Me.CharacterLevel = characterLevel
            Me.AdditionalTraits = addtionalTraits
        End Sub

    End Class

End Namespace