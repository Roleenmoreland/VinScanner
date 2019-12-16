namespace VinScanner.Interfaces
{
    public interface ISmsService
    {
        bool Send(int mobileNumber, string message, string title = "", string from = "");
        bool Send(int mobileNumber, string template, string messagePlaceHolders = "");

    }
}
