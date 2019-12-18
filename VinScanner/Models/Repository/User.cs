using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VinScanner.Models.Repository
{
    public class User : IdentityUser
    {
        [Key]
        public int UserId{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }

    }
}
