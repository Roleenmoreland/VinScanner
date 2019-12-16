using Microsoft.Extensions.Logging;
using VinScanner.Interfaces;
using VinScanner.Models;
using VinScanner.Models.Repository;

namespace VinScanner.Services
{
    public class DealerService : IDealerService
    {
        private readonly ILogger<DealerService> _logger;
        private readonly IDealerRepository _dealerRepo;
        private readonly IClientRepository _clientRepo;
        private readonly ISmsService _smsService;

        public DealerService(ILogger<DealerService> logger, IDealerRepository dealerRepo, IClientRepository clientRepo,
            ISmsService smsService)
        {
            _logger = logger;
            _dealerRepo = dealerRepo;
            ClientRepo = clientRepo;
            _smsService = smsService;
        }

        public IClientRepository ClientRepo { get; }

        public bool Login(string username, string password)
        {
            var isValidDealer = _dealerRepo.CheckCredentials(username, password);
            return isValidDealer;
        }

        public bool Register(Dealer dealer)
        {
            //Check to see if user already exist
            var isAvailableUserDetails = _dealerRepo.CheckAvailability(dealer.UserName, dealer.EmailAddress);
            if (isAvailableUserDetails)
            {
                _dealerRepo.AddDealer(dealer);
                return true;
            }

            return false;
        }

        public bool RequestVechileDetails(RequestVechilDetails request)
        {
            var client = _clientRepo.GetClient(request.ClientName, request.MobileNumber);
            if (client == null)
            {
                client = _clientRepo.AddClient(new Client
                {
                    EmailAddress = request.EmailAddress,
                    MobileNumber = request.MobileNumber,
                    Name = request.ClientName,
                    Surname = request.ClientSurname
                });
            }

            var successful = _smsService.Send(request.MobileNumber, "ScanRequest", "https://localhost:4000/scanner?dealer=1");

            return successful;
        }
    }
}
