namespace NumberToWordsLib.Handlers
{
    // Concrete handler for billions
    public class BillionsHandler : NumberHandler
    {
        public override string Handle(int number)
        {
            if (number >= 1000000000 && number < 1000000000000)
            {
                int billions = number / 1000000000;
                int remainder = number % 1000000000;
                return NumberToWordsBelow1000(billions) + " billion" + (remainder > 0 ? " " + Handle(remainder) : "");
            }
            else
            {
                return base.Handle(number);
            }
        }
    }
}
