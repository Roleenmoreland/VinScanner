using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VinScanner.Interfaces;
using VinScanner.Models;
using VinScanner.Models.Repository;

namespace VinScanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly ILogger<DealerController> _logger;
        private readonly IDealerService _dealerService;

        public DealerController(ILogger<DealerController> logger, IDealerService dealerService)
        {
            _logger = logger;
            _dealerService = dealerService;
        }


        [HttpPost()]
        public void Login([FromBody] string username, [FromBody] string password)
        {
            try
            {
                var isSuccessful = _dealerService.Login(username, password);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to login.", e, username);
                BadRequest();
            }
        }

        [HttpPost()]
        public void Register([FromBody] Dealer dealer)
        {
            try
            {
                var isSuccessful = _dealerService.Register(dealer);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to Register a new Dealer.", e, dealer.UserName, dealer.EmailAddress);
                BadRequest();
            }
        }

        [HttpPost()]
        public void RequestVechilDetails(RequestVechilDetails request)
        {
            try
            {
                var isSuccessful = _dealerService.RequestVechileDetails(request);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to request the vechile details for a client.", e, request);
                BadRequest();
            }
        }
    }
}