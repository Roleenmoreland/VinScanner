using System;
using System.Threading.Tasks;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;

namespace VinScanner.Services
{
    public class ScannerService : IScannerService
    {
        private readonly INpTrackerBroker _npTrackerBroker;
        private readonly IVechileDetailsRepository _vechileDetailsRepository;

        public ScannerService(INpTrackerBroker npTrackerBroker, IVechileDetailsRepository vechileDetailsRepository)
        {
            _npTrackerBroker = npTrackerBroker;
            _vechileDetailsRepository = vechileDetailsRepository;
        }

        public async Task<VechileDetails> ScanVinNumber(string vinNumber, User user)
        {
            if (vinNumber.Length == 12)
            {
                var vechileDetails = await _vechileDetailsRepository.Get(vinNumber);
                if (vechileDetails != null)
                {
                    var response = await _npTrackerBroker.VechileCheckReport(vinNumber);
                    return new VechileDetails
                    {
                        Colour = response.Results.Colour,
                        Description = response.Results.Description,
                        Engine = response.Results.Engine,
                        Make = response.Results.Make,
                        Model = response.Results.Model,
                        Plate = response.Results.Plate,
                        Vin = response.Results.VIN,
                        User = user
                    };
                }
            }
            throw new ApplicationException("Could not Scan the vin number");
        }
    }
}
