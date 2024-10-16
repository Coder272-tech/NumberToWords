﻿using NumberToWordsLib.Interfaces;

namespace NumberToWordsLib
{
    // Chain of Responsibility pattern
    // Base class for handlers implementing the chaining mechanism
    public abstract class NumberHandler : INumberHandler
    {
        private INumberHandler _nextHandler;

        public INumberHandler SetNext(INumberHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual string Handle(int number)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(number);
            }
            return string.Empty;
        }

        protected string NumberToWordsBelow1000(int number)
        {
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
                return unitsMap[number];
            else if (number < 100)
            {
                int tens = number / 10;
                int units = number % 10;
                return tensMap[tens] + (units > 0 ? "-" + unitsMap[units] : "");
            }
            else
            {
                int hundreds = number / 100;
                int remainder = number % 100;
                return unitsMap[hundreds] + " hundred" + (remainder > 0 ? " " + NumberToWordsBelow1000(remainder) : "");
            }
        }
    }
}