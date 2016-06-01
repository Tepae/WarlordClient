Namespace GameEngine.Card

    Public Interface IRangedStriker
        Function GetFilterForRangedStrike() As ClickFilter.ClickFilter
        Function GetRangedStrikes() As Strike.StrikeSet
    End Interface

End Namespace