namespace NumberToWordsLib.Handlers
{
    // Concrete handler for units (less than 1000)
    public class UnitsHandler : NumberHandler
    {
        public override string Handle(long number)
        {
            if (number < 1000)
            {
                return NumberToWordsBelow1000(number);
            }
            else
            {
                return base.Handle(number);
            }
        }
    }
}
