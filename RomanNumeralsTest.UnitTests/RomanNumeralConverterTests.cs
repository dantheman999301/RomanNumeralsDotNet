using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RomanNumeralsTest;
using Xunit;

namespace RomanNumerals.UnitTests;

public class RomanNumeralConverterTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void GivenANumber_WhenConverted_RomanNumeralIsCorrect(RomanNumeral originalRomanNumeral)
    {
        var romanNumeral = RomanNumeralConverter.ToNumeral(originalRomanNumeral.ToInt());
        romanNumeral.Should().Be(originalRomanNumeral.ToString());
    }
    
    [Fact(Skip = "Manual Test")]
    public void GivenASpecificNumber_WhenConverted_RomanNumeralIsCorrect()
    {
        const int testNumber = 346;
        var originalRomanNumeral = new RomanNumeral(testNumber);
        var romanNumeral = RomanNumeralConverter.ToNumeral(originalRomanNumeral.ToInt());
        romanNumeral.Should().Be(originalRomanNumeral.ToString());
    }

    // I'm assuming at this point that the imported library is correct.
    public static IEnumerable<object[]> Data =>
        Enumerable
            .Range(1, 2000)
            .Select(i => new[] { new RomanNumeral(i) });
}
