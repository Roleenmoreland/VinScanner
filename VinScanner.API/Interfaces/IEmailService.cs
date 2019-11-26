using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinScanner.API.Interfaces
{
    interface IEmailService
    {
        bool Send(string to, string message);
    }
}
