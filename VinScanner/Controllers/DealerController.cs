using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        [Authorize(Policy = "DealerRole")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var isSuccessful = await _dealerService.Login(request.Username, request.Password);
                return Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to login.", e, request.Username);
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult> Register([FromBody] Dealer dealer)
        {
            try
            {
                var isSuccessful = await _dealerService.Register(dealer);
                return  Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to Register a new Dealer.", e, dealer.UserName, dealer.EmailAddress);
                return BadRequest();
            }
        }

        [Authorize(Policy = "DealerRole")]
        [HttpPost()]
        public async Task<ActionResult> RequestVechileDetails([FromBody] User request)
        {
            try
            {
                var isSuccessful = await _dealerService.RequestVechileDetails(request);
                return Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to request the vechile details for a user.", e, request);
                return BadRequest();
            }
        }
    }
}