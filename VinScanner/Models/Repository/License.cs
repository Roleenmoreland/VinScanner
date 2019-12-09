using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinScanner.Models.Repository
{
    public class License
    {
        public string VinNumber { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpireDate { get; set; }
        public VechileDetails VechileDetails { get; set; }

    }
}
