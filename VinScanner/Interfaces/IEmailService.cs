namespace VinScanner.Interfaces
{
    public interface IEmailService
    {
        bool Send(string to, string message);
    }
}