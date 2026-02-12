
using NSubstitute.ReturnsExtensions;

public class Calculator
{
    public int Add(string numbers)
    {
        // If there's multiple numbers
        int result = 0;
        // Comma as delimiter
        // var separator = ",";

        // Multiple delimiters
        char[] delimeters = { ',', '\n' };
        if (numbers == "")
        {
            return result;
        }
        string[] allNums = numbers.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        foreach (var num in allNums)
        {
            result += int.Parse(num);
        }
        return result; 

    }
}
