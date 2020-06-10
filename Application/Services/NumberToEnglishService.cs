using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Application.Services
{
    public class NumberToEnglishService
    {
        private readonly string[] numbersBelowTwentyMap;
        private readonly Dictionary<int, string> tensMap;

        public NumberToEnglishService()
        {
            this.numbersBelowTwentyMap = new[]
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
                "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            this.tensMap = new Dictionary<int, string>
            {
                { 2, "twenty" },
                { 3, "thirty" },
                { 4, "forty" },
                { 5, "fifty" },
                { 6, "sixty" },
                { 7, "seventy" },
                { 8, "eighty" },
                { 9, "ninety" },
            };
        }

        public string NumberToEnglish(decimal number)
        {
            var sb = new StringBuilder();

            var wholeNumberPart = (long)Decimal.Truncate(number);
            var decimalPart = number - wholeNumberPart;
            if (wholeNumberPart < 0)
            {
                sb.Append("negative ");
                wholeNumberPart = Math.Abs(wholeNumberPart);
                decimalPart = Math.Abs(decimalPart);
            }

            sb.Append(this.WholeNumberToEnglish(wholeNumberPart, true));

            if (decimalPart > 0)
            {
                sb.Append(" point ");
                sb.Append(this.DecimalToEnglish(decimalPart));
            }

            return sb.ToString();
        }

        private string DecimalToEnglish(decimal number)
        {
            if (number > 1)
            {
                throw new ArgumentException("argument must be less than 1", nameof(number));
            }

            // there's probably a more efficient way to do this than converting things back and forth between strings
            // and chars and ints (memory allocs!) but let's do the naive straightforward approach, surround with
            // tests and come back to optimise later (maybe with benchmarks).

            var numberString = number.ToString(CultureInfo.InvariantCulture);
            numberString = numberString.Substring(2, numberString.Length - 2);

            var sb = new StringBuilder();
            foreach (var character in numberString)
            {
                var digit = int.Parse(character.ToString());
                sb.Append(this.numbersBelowTwentyMap[digit]);
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }

        private string WholeNumberToEnglish(long number, bool firstCall = false)
        {
            // TODO: a bit of DRY in here checking remainders, be nice to tidy it up

            var sb = new StringBuilder();

            if (number >= 1000000000)
            {
                sb.Append($"{this.NumberToEnglish(number / 1000000000)} billion");
                var remainder = number % 1000000000;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                if (remainder < 1000)
                {
                    sb.Append(" and");
                }

                sb.Append($" {this.NumberToEnglish(remainder)}");
                return sb.ToString();
            }

            if (number / 1000000 >= 1)
            {
                sb.Append($"{this.WholeNumberToEnglish(number / 1000000)} million");
                var remainder = number % 1000000;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                if (remainder < 1000)
                {
                    sb.Append(" and");
                }

                sb.Append($" {this.WholeNumberToEnglish(remainder)}");
                return sb.ToString();
            }

            if (number / 1000 >= 1)
            {
                sb.Append($"{this.WholeNumberToEnglish(number / 1000)} thousand");
                var remainder = number % 1000;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                if (remainder < 100)
                {
                    sb.Append(" and");
                }

                sb.Append($" {this.WholeNumberToEnglish(remainder)}");

                return sb.ToString();
            }

            if (number / 100 >= 1)
            {
                sb.Append($"{this.WholeNumberToEnglish(number / 100)} hundred");
                var remainder = number % 100;
                if (remainder == 0)
                {
                    // do not recurse
                    return sb.ToString();
                }

                sb.Append($" and {this.WholeNumberToEnglish(remainder)}");

                return sb.ToString();
            }

            if (number / 10 >= 2)
            {
                sb.Append(this.tensMap[(int)(number / 10)]);
                var remainder = number % 10;

                if (remainder == 0)
                {
                    return sb.ToString();
                }

                sb.Append($" {this.WholeNumberToEnglish(number % 10)}");
            }

            if (number < 20)
            {
                if (!firstCall && number == 0)
                {
                    return string.Empty;
                }

                // cast is safe, we're checking size of the decimal
                sb.Append(this.numbersBelowTwentyMap[(int)number]);
            }

            return sb.ToString();
        }
    }
}