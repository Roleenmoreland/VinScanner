using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VinScanner.Interfaces;
using VinScanner.Models.Repository;

namespace VinScanner.Services
{
    public class DealerService : IDealerService
    {
        private readonly ILogger<DealerService> _logger;
        private readonly IDealerRepository _dealerRepo;
        private readonly IUserRepository _userRepo;
        private readonly ISmsService _smsService;
        private readonly string _baseUrl;

        public DealerService(ILogger<DealerService> logger, IDealerRepository dealerRepo, IUserRepository userRepo,
            ISmsService smsService, IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("BaseURL").Value;
            _logger = logger;
            _dealerRepo = dealerRepo;
            _userRepo = userRepo;
            _smsService = smsService;
        }

        public async Task<bool> Login(string username, string password)
        {
            var isValidDealer = await _dealerRepo.CheckCredentials(username, password);
            return isValidDealer;
        }

        public async Task<bool> Register(Dealer dealer)
        {
            //Check to see if user already exist
            var isAvailableUserDetails = await _dealerRepo.CheckAvailability(dealer.UserName, dealer.EmailAddress);
            if (isAvailableUserDetails)
            {
                await _dealerRepo.AddDealer(dealer);
                return true;
            }

            return false;
        }

        public async Task<bool> RequestVechileDetails(User request)
        {
            var user = await _userRepo.GetUser(request.Name, request.MobileNumber);
            if (user == null)
            {
                user = await _userRepo.AddUser(user);
            }

            var successful = _smsService.Send(request.MobileNumber, "ScanRequest", $"{_baseUrl}/scanner?userId={user.UserId}");

            return successful;
        }
    }
}
