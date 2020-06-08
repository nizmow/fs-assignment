using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class NumberToEnglishService
    {
        private readonly string[] numbersBelowTwentyMap;
        private readonly Dictionary<int, string> tensMap;
        private readonly string[] magnitudesMap;

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

        public string NumberToEnglish(int number)
        {
            return this.NumberToEnglishInternal(number, true);
        }

        private string NumberToEnglishInternal(int number, bool firstCall = false)
        {
            // if (number >= 1000000000)
            // {
            //     var sb = new StringBuilder($"{this.NumberToEnglish(number / 1000000000)} billion");
            //     var remainder = number % 1000000000;
            //     if (remainder == 0)
            //     {
            //         return sb.ToString();
            //     }
            //
            //     if (remainder < 1000)
            //     {
            //         sb.Append(" and");
            //     }
            //
            //     sb.Append($" {this.NumberToEnglish(remainder)}");
            //     return sb.ToString();
            // }

            var sb = new StringBuilder();

            if (number / 1000000 >= 1)
            {
                sb.Append($"{this.NumberToEnglishInternal(number / 1000000)} million");
                var remainder = number % 1000000;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                if (remainder < 1000)
                {
                    sb.Append(" and");
                }

                sb.Append($" {this.NumberToEnglishInternal(remainder)}");
                return sb.ToString();
            }

            if (number / 1000 >= 1)
            {
                sb.Append($"{this.NumberToEnglishInternal(number / 1000)} thousand");
                var remainder = number % 1000;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                if (remainder < 100)
                {
                    sb.Append(" and");
                }

                sb.Append($" {this.NumberToEnglishInternal(remainder)}");

                return sb.ToString();
            }

            if (number / 100 >= 1)
            {
                sb.Append($"{this.NumberToEnglishInternal(number / 100)} hundred");
                var remainder = number % 100;
                if (remainder == 0)
                {
                    // do not recurse
                    return sb.ToString();
                }

                sb.Append($" and {this.NumberToEnglishInternal(remainder)}");

                return sb.ToString();
            }

            if (number / 10 >= 2)
            {
                sb.Append(this.tensMap[number / 10]);
                var remainder = number % 10;
                if (remainder == 0)
                {
                    return sb.ToString();
                }

                sb.Append($" {this.NumberToEnglishInternal(number % 10)}");
            }

            if (number < 20)
            {
                if (!firstCall && number == 0)
                {
                    return string.Empty;
                }
                sb.Append(this.numbersBelowTwentyMap[number]);
            }

            return sb.ToString();
        }
    }
}