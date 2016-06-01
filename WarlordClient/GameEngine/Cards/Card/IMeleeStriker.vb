Namespace GameEngine.Card

    Public Interface IMeleeStriker
        Function GetFilterForMeleeStrike() As ClickFilter.ClickFilter
        Function GetMeleeStrikes() As Strike.StrikeSet
    End Interface

End Namespace