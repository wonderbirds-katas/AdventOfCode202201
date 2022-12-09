﻿namespace Day02RockPaperScissors.Tests;

public class LineParserTests
{
    private readonly LineParser _lineParser = new();

    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("B X", ShapeScore.Paper)]
    [InlineData("C X", ShapeScore.Scissors)]
    public void OpponentShape(string line, ShapeScore expectedOpponentShape)
    {
        (var actual, var _) = _lineParser.ParseLine(line);

        Assert.Equal(expectedOpponentShape, actual);
    }

    [Theory]
    [InlineData("A X", ShapeScore.Rock)]
    [InlineData("A Y", ShapeScore.Paper)]
    [InlineData("A Z", ShapeScore.Scissors)]
    public void OwnShape(string line, ShapeScore expectedOwnShape)
    {
        (var _, var actual) = _lineParser.ParseLine(line);

        Assert.Equal(expectedOwnShape, actual);
    }
}