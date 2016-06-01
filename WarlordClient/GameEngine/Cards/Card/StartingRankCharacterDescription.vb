Namespace GameEngine.Card

    Public Class StartingRankCharacterDescription

        Public CharacterClass As Character.Class = Character.Class.Any
        Public CharacterRace As Character.Race = Character.Race.Any
        Public CharacterLevel As Integer = -1
        Public AdditionalTraits As List(Of Character.CharacterTrait) = Nothing

        Public Sub New(characterClass As Character.Class, characterRace As Character.Race, characterLevel As Integer, Optional ByVal addtionalTraits As List(Of Character.CharacterTrait) = Nothing)
            Me.CharacterClass = characterClass
            Me.CharacterRace = characterRace
            Me.CharacterLevel = characterLevel
            Me.AdditionalTraits = addtionalTraits
        End Sub

    End Class

End Namespace