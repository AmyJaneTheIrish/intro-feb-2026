

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    public void SingleDigit(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1, 2", 3)]
    public void DoubleIntegers(string input, int expected)
    {
        var calculator = new Calculator();
        var result3 = calculator.Add(input);

        Assert.Equal(expected, result3);
    }

    [Theory]
    [InlineData("1,2,3,4,5", 15)]
    public void MultipleIntegers(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    public void NewlineDelimeter(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    public void DifferentDelimeter(string input, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(input);

        Assert.Equal(expected, result);
    }
}
