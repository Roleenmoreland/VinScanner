namespace VinScanner.Models
{
    public class SendVechileDetailsRequest
    {
        public string Vin { get; set; }
        public int DealerId { get; set; }
        public int UserId { get; set; }

    }
}
