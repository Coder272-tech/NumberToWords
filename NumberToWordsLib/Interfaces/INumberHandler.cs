namespace NumberToWordsLib.Interfaces
{
    public interface INumberHandler
    {
        INumberHandler SetNext(INumberHandler handler);
        string Handle(int number);
    }
}