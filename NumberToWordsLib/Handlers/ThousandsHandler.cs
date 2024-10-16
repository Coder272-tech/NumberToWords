namespace NumberToWordsLib.Handlers
{
    // Concrete handler for thousands
    public class ThousandsHandler : NumberHandler
    {
        public override string Handle(long number)
        {
            if (number >= 1000 && number < 1000000)
            {
                long thousands = number / 1000;
                long remainder = number % 1000;
                return NumberToWordsBelow1000(thousands) + " thousand" + (remainder > 0 ? " " + Handle(remainder) : "");
            }
            else
            {
                return base.Handle(number);
            }
        }
    }
}
