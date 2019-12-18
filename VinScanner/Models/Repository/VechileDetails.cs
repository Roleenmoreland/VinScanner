namespace VinScanner.Models.Repository
{
    public class VechileDetails
    {
        public int VechileDetailsId { get; set; }
        public string Plate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string Vin { get; set; }
        public string Engine { get; set; }
        public User User { get; set; }
    }
}