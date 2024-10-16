namespace NumberToWordsLib.Handlers
{
    // Concrete handler for thousands
    public class ThousandsHandler : NumberHandler
    {
        public override string Handle(int number)
        {
            if (number >= 1000 && number < 1000000)
            {
                int thousands = number / 1000;
                int remainder = number % 1000;
                return NumberToWordsBelow1000(thousands) + " thousand" + (remainder > 0 ? " " + Handle(remainder) : "");
            }
            else
            {
                return base.Handle(number);
            }
        }
    }
}
