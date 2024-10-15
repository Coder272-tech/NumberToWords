namespace NumberToWordsLib
{
    public static class NumberToWords
    {
        public static string ConvertAmountToWords(decimal amount)
        {
            // Separate the integer and fractional parts
            int integerPart = (int)Math.Floor(amount);
            int fractionalPart = (int)((amount - integerPart) * 100);

            // Convert the integer part to words
            string integerPartWords = ConvertNumberToWords(integerPart);

            // Construct the final string representation
            string result = $"{integerPartWords} and {fractionalPart:D2}/100 dollars";
            // Capitalize the first character
            result = char.ToUpper(result[0]) + result.Substring(1);
            return result;
        }

        private static string ConvertNumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "Negative " + ConvertNumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000) > 0)
            {
                words += ConvertNumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertNumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                // Removing this because I mistakenly thought the provided unit test wanted "and" in the dollars portion
                /*
                if (words != "")
                    words += "and ";
                */

                var unitsMap = new[]
                {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
                "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
                "seventeen", "eighteen", "nineteen"
            };
                var tensMap = new[]
                {
                "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
                "eighty", "ninety"
            };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }
    }
}
