namespace VinScanner.Interfaces
{
    public interface INexmoBroker
    {
        bool SendSms(string to, string message, string title = "", string from = "");
    }
}
