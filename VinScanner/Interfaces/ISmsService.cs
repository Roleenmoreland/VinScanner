namespace VinScanner.Interfaces
{
    public interface ISmsService
    {
        bool Send(string to, string message);
    }
}
