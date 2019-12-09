using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinScanner.Interfaces;

namespace VinScanner.Services
{
    public class ScannerService : IScannerService
    {
        public ScannerService()
        {

        }

        public void ScanVinNumber(string vinNumber)
        {
            //1. validate number
            //2. check if existing
            //3. upsert data

            if(vinNumber.Length == 12)
            {

            }
        }
    }
}
