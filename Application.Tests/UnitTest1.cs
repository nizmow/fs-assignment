using System;
using Application.Domain;
using FluentAssertions;
using Xunit;

namespace Application.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, "zero")]
        [InlineData(8, "eight")]
        [InlineData(37, "thirty seven")]
        [InlineData(300, "three hundred")]
        [InlineData(422, "four hundred and twenty two")]
        [InlineData(2367, "two thousand three hundred and sixty seven")]
        [InlineData(23000, "twenty three thousand")]
        [InlineData(43012, "forty three thousand and twelve")]
        [InlineData(70129, "seventy thousand one hundred and twenty nine")]
        [InlineData(7836197, "seven million eight hundred and thirty six thousand one hundred and ninety seven")]
        [InlineData(256000000, "two hundred and fifty six million")]
        public void Test1(int input, string expectedResult)
        {
            var target = new NumberToEnglishService();

            var result = target.NumberToEnglish(input);

            result.Should().Be(expectedResult);
        }
    }
}