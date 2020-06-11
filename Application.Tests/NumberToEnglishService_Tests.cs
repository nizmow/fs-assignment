using System.Runtime.InteropServices;
using Application.Services;
using FluentAssertions;
using Xunit;

namespace Application.Tests
{
    public class NumberToEnglishService_Tests
    {
        [Theory]
        [InlineData(-283, "negative two hundred and eighty three")]
        [InlineData(-11.25, "negative eleven point two five")]
        [InlineData(0.32023, "zero point three two zero two three")]
        [InlineData(0, "zero")]
        [InlineData(8, "eight")]
        [InlineData(37, "thirty seven")]
        [InlineData(300, "three hundred")]
        [InlineData(422, "four hundred and twenty two")]
        [InlineData(2367, "two thousand three hundred and sixty seven")]
        [InlineData(23000, "twenty three thousand")]
        [InlineData(43000.123, "forty three thousand point one two three")]
        [InlineData(59012, "fifty nine thousand and twelve")]
        [InlineData(70129, "seventy thousand one hundred and twenty nine")]
        [InlineData(7836197, "seven million eight hundred and thirty six thousand one hundred and ninety seven")]
        [InlineData(256000000, "two hundred and fifty six million")]
        [InlineData(83013123001, "eighty three billion thirteen million one hundred and twenty three thousand and one")]
        public void CalculateEnglish_WithValidNumber_Succeeds(decimal input, string expectedResult)
        {
            var target = new NumberToEnglishService();

            var result = target.CalculateEnglish(input);

            result.Should().Be(expectedResult);
        }
    }
}