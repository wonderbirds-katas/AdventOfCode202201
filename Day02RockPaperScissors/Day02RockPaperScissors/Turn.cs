namespace Day02RockPaperScissors;

public static class Turn
{
    public static Score Score(ShapeScore opponent, ShapeScore own)
    {
        var outcome = CalculateOutcome(opponent, own);

        return new Score(own, outcome);
    }

    private static OutcomeScore CalculateOutcome(ShapeScore opponent, ShapeScore own)
    {
        if (own == opponent)
        {
            return OutcomeScore.Draw;
        }

        if (own > opponent)
        {
            return OutcomeScore.Win;
        }

        return OutcomeScore.Lose;
    }
}
