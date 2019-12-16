using System.ComponentModel.DataAnnotations;

namespace VinScanner.Models.Repository
{
    public class Dealer
    {
        [Key]
        public int DealerId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }

    }
}
