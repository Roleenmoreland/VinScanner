namespace VinScanner.Interfaces
{
    public interface INexmoBroker
    {
        bool Send(string to, string message, string title, string from);

    }
}
