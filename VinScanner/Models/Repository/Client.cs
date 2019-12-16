using System.ComponentModel.DataAnnotations;

namespace VinScanner.Models.Repository
{
    public class Client
    {
        [Key]
        public int ClientId{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int MobileNumber { get; set; }
        public string EmailAddress { get; set; }

    }
}
