using System.Text;

namespace RomanNumeralsTest;

public static class RomanNumeralConverter
{
    private static readonly SortedList<int, string> IntToRomanMap = new(new DescendingComparer())
    {
        // The maps with two letters are to deal with cases where you cannot
        // repeat a letter more than 3 times. Simplest example being 4 (IV vs IIII)
        { 1000, "M" },
        { 900, "CM"},
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public static string ToNumeral(int originalNumber)
    {
        if (originalNumber is <= 0 or > 2000)
        {
            throw new ArgumentException("Number must be between 1 and 2000", nameof(originalNumber));
        }
        
        var remainder = originalNumber;
        var stringBuilder = new StringBuilder();
        foreach (var (numeralValue, numeral) in IntToRomanMap)
        {
            if (remainder == 0)
            {
                break;
            }
            
            var letterAmount = remainder / numeralValue;
            
            if (letterAmount == 0)
            {
                continue;
            }
            
            remainder %= numeralValue;
            stringBuilder.Append(string.Concat(Enumerable.Repeat(numeral, letterAmount)));
        }

        return stringBuilder.ToString();
    }

    private class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
