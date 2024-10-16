namespace NumberToWordsLib.Handlers
{
    // Concrete handler for millions
    public class MillionsHandler : NumberHandler
    {
        public override string Handle(int number)
        {
            if (number >= 1000000 && number < 1000000000)
            {
                int millions = number / 1000000;
                int remainder = number % 1000000;
                return NumberToWordsBelow1000(millions) + " million" + (remainder > 0 ? " " + Handle(remainder) : "");
            }
            else
            {
                return base.Handle(number);
            }
        }
    }
}
