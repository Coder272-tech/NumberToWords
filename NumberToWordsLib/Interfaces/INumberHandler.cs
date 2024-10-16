namespace NumberToWordsLib.Interfaces
{
    public interface INumberHandler
    {
        INumberHandler SetNext(INumberHandler handler);
        string Handle(long number);
    }
}