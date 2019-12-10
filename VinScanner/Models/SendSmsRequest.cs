namespace VinScanner.Models
{
    public class SendSmsRequest
    {
        public string To { get; set; }
        public string Message { get; set; }
        public string Title { get; set; } //todo make nullable
        public string From { get; set; }    
    }
}
