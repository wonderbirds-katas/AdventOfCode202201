namespace Day03RucksackReorganization.Tests;
using FluentAssertions;

public class RucksackParserTests
{
    [Fact]
    public void EmptyLine()
    {
        const string emptyLine = "";
        var actual = emptyLine.Parse();

        actual.FirstCompartment.Items.Should().BeEmpty();
        actual.SecondCompartment.Items.Should().BeEmpty();
    }
    
    // TODO: Create RucksackParserTests for edge case of odd number of Items
    
    [Theory]
    [InlineData('a', 'b')]
    [InlineData('c', 'd')]
    public void LineWithTwoItems(char firstItemType, char secondItemType)
    {
        var firstItem = new Item(firstItemType);
        var secondItem = new Item(secondItemType);
        var lineWithTwoItems = $"{firstItem.Type}{secondItem.Type}";
        
        var expected = new Rucksack();
        AddItemToCompartment(firstItem, expected.FirstCompartment);
        AddItemToCompartment(secondItem, expected.SecondCompartment);

        var actual = lineWithTwoItems.Parse();

        actual.Should().BePackedLike(expected);
    }

    [Theory]
    [InlineData(new [] {'a', 'b'}, new []{'c', 'd'})]
    [InlineData(new [] {'Z', 'z'}, new []{'X', 'X'})]
    public void LineWithFourItems(char[] itemsInFirstCompartment, char[] itemsInSecondCompartment)
    {
        var line = ItemsToString(itemsInFirstCompartment, itemsInSecondCompartment);

        var actual = line.Parse();

        var expected = PackRucksackWith(itemsInFirstCompartment, itemsInSecondCompartment);
        actual.Should().BePackedLike(expected);
    }

    private static string ItemsToString(char[] itemsInFirstCompartment, char[] itemsInSecondCompartment)
    {
        return new string(itemsInFirstCompartment) + new string(itemsInSecondCompartment);
    }

    private static Rucksack PackRucksackWith(char[] itemsInFirstCompartment, char[] itemsInSecondCompartment)
    {
        var expected = new Rucksack();

        foreach (var itemType in itemsInFirstCompartment)
        {
            AddItemToCompartment(new Item(itemType), expected.FirstCompartment);
        }

        foreach (var itemType in itemsInSecondCompartment)
        {
            AddItemToCompartment(new Item(itemType), expected.SecondCompartment);
        }

        return expected;
    }

    private static void AddItemToCompartment(Item item, Compartment compartment)
    {
        compartment.Add(item);
        compartment.Items.Should().Contain(x => x == item);
    }
}
