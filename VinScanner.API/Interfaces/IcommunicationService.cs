using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinScanner.API.Services;

namespace VinScanner.API.Interfaces
{
    public interface ICommunicationService<T> where T : class
    {
        bool Send(string to, string message);

    }
}
