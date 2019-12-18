namespace VinScanner.Interfaces
{
    public interface ISmsService
    {
        bool Send(string mobileNumber, string message, string title = "", string from = "");
        bool Send(string mobileNumber, string template, string messagePlaceHolders = "");

    }
}
