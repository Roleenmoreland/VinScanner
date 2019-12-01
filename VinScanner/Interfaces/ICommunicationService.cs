namespace VinScanner.Interfaces
{
    public interface ICommunicationService<T> where T : class
    {
        bool Send(string to, string message);

    }
}
