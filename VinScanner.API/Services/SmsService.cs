using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using VinScanner.API.Interfaces;

namespace VinScanner.API.Services
{
    public class SmsService : ICommunicationService<SmsService>
    {
        public bool Send(string to, string message)
        {
            //var serialPort = new SerialPort();
            return true;
        }
    }
}
