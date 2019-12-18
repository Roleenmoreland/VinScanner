namespace VinScanner.Models
{
    public class ScanVinNumberRequest
    {
        public string MobileNumber { get; set; }
        public int DealerId { get; set; }
        public string VinNumber { get; set; }   
    }
}
