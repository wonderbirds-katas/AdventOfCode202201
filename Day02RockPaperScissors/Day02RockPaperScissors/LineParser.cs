﻿namespace Day02RockPaperScissors;

public static class LineParserExtensions
{
    public static Round ParseShapes(this string line)
    {
        var opponentShape = line[0] switch
        {
            'A' => ShapeScore.Rock,
            'B' => ShapeScore.Paper,
            'C' => ShapeScore.Scissors
        };

        var ownShape = line[2] switch
        {
            'X' => ShapeScore.Rock,
            'Y' => ShapeScore.Paper,
            'Z' => ShapeScore.Scissors
        };

        return new Round(opponentShape, ownShape);
    }
}