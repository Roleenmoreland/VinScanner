using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinScanner.Models
{
    public class EmailContent
    {
        public string Message { get; set; }
        public string Subject { get; set; }
        public string From  { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

    }
}
