namespace VinScanner.Interfaces
{
    public interface INexmoBroker
    {
        bool SendSms(int to, string message, string title = "", string from = "");

    }
}
