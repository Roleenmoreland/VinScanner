namespace VinScanner.Models
{
    public class VechileCheckReportResponse
    {
        public Results Results { get; set; }
    }
    public class Results
    {
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string VIN { get; set; }
        public string Engine { get; set; }
        public string SourceID { get; set; }
        public string PictureURL { get; set; }
    }
}
