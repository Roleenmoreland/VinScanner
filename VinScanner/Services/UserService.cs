using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Services
{
    public class UserService : IUserService
    {
        private readonly IScannerService _scannerService;
        private readonly IUserRepository _userRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger;

        public UserService(IScannerService scannerService, IUserRepository userRepository, IDealerRepository dealerRepository, IEmailService emailService,
            ILogger<UserService> logger)
        {
            _scannerService = scannerService;
            _userRepository = userRepository;
            _dealerRepository = dealerRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<bool> SendVechileDetails(SendVechileDetailsRequest request)
        {
            try
            {
                var user = await _userRepository.GetUser(request.UserId);

                var response = await _scannerService.ScanVinNumber(request.Vin, user);
                if (response != null)
                {
                    var dealer = await _dealerRepository.Get(request.DealerId);
                    var replacements = new string[] { user.Name, request.Vin };
                    var isSuccessful = await _emailService.Send(dealer.Email, "ScanRequest", replacements);
                    return true;
                }
                _logger.LogError("Could not retrieve the vechile details base of the vin number", request);
                return false;
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred trying to send the vechile details request to the dealer.", request);
                return false;
            }
        }
    }
}
