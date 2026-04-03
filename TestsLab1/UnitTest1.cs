namespace TestsLab1;

using Xunit;


public class Deluppgift1Test
{
    [Fact]
    public void GetOccurences_Match()
    {
        int[] input = { 0, 1, 2, 3, 4, 5 };
        int expected = 1;

        var result = Deluppgift1.GetOccurences(input, 3);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetOccurences_MultipleMatch()
    {
        int[] input = { 2, 1, 2, 3, 2, 5 };
        int expected = 3;

        var result = Deluppgift1.GetOccurences(input, 2);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOccurences_NoMatch()
    {

        int[] input = { 0, 1, 2, 3, 4, 5 };
        int expected = 0;

        var result = Deluppgift1.GetOccurences(input, -3);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOccurences_AllMatch()
    {
        int[] input = { 5, 5, 5, 5, 5, 5 };
        int expected = 6;

        var result = Deluppgift1.GetOccurences(input, 5);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetOccurences_EmptyArray()
    {
        int[] input = { };
        int expected = 0;

        var result = Deluppgift1.GetOccurences(input, 5);
        Assert.Equal(expected, result);
    }
}

public class Deluppgift2Test
{
    [Fact]
    public void Deluppgift2_ReverseA_ReverseArray()
    {
        int[] input = { 1, 2, 3, 4, 5, 6 };
        int[] expected = { 6, 5, 4, 3, 2, 1 };

        var result = Deluppgift2.ReverseA(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseA_ArrayIsEmpty()
    {
        int[] input = { };
        int[] expected = { };

        var result = Deluppgift2.ReverseA(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseA_SingleElement()
    {
        int[] input = { 42 };
        int[] expected = { 42 };

        var result = Deluppgift2.ReverseA(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseA_TwoElements()
    {
        int[] input = { 1, 2 };
        int[] expected = { 2, 1 };

        var result = Deluppgift2.ReverseA(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseA_OddLength()
    {
        int[] input = { 1, 2, 3 };
        int[] expected = { 3, 2, 1 };

        var result = Deluppgift2.ReverseA(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseB_ReverseArray()
    {
        int[] input = { 1, 2, 3, 4, 5, 6 };
        int[] expected = { 6, 5, 4, 3, 2, 1 };

        var result = Deluppgift2.ReverseB(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseB_ArrayIsEmpty()
    {
        int[] input = { };
        int[] expected = { };

        var result = Deluppgift2.ReverseB(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseB_SingleElement()
    {
        int[] input = { 42 };
        int[] expected = { 42 };

        var result = Deluppgift2.ReverseB(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseB_TwoElements()
    {
        int[] input = { 1, 2 };
        int[] expected = { 2, 1 };

        var result = Deluppgift2.ReverseB(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Deluppgift2_ReverseB_OddLength()
    {
        int[] input = { 1, 2, 3 };
        int[] expected = { 3, 2, 1 };

        var result = Deluppgift2.ReverseB(input, input.Length);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseA_and_ReverseB_ProduceSameResult()
    {
        int[] inputA = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] inputB = (int[])inputA.Clone();

        var resultA = Deluppgift2.ReverseA(inputA, inputA.Length);
        var resultB = Deluppgift2.ReverseB(inputB, inputB.Length);

        Assert.Equal(resultA, resultB);
    }
}

