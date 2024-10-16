using NumberToWordsLib.Handlers;
using NumberToWordsLib.Interfaces;

namespace NumberToWordsLib
{
    // The processor that sets up the chain
    public class NumberToWordsProcessor
    {
        private readonly INumberHandler _handlerChain;

        public NumberToWordsProcessor()
        {
            _handlerChain = new BillionsHandler();
            _handlerChain
                .SetNext(new MillionsHandler())
                .SetNext(new ThousandsHandler())
                .SetNext(new UnitsHandler());  // Add UnitsHandler to handle numbers < 1000
        }

        public string Convert(decimal amount)
        {
            // Split the amount into integer and fractional parts
            int integerPart = (int)Math.Floor(amount);
            int fractionalPart = (int)((amount - integerPart) * 100);

            // Convert the integer part using the chain of responsibility
            string integerPartWords = _handlerChain.Handle(integerPart);

            // Convert the fractional part (cents)
            string fractionalPartWords = $"{fractionalPart:D2}/100";

            // Combine the result and capitalize the first letter
            string result = $"{integerPartWords} and {fractionalPartWords} dollars";
            return char.ToUpper(result[0]) + result.Substring(1);
        }
    }
}
