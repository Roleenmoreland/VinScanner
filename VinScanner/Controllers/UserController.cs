using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost()]
        public async Task ScanVinNumber(SendVechileDetailsRequest request)
        {
            try
            {
                var isSuccessfull = await _userService.SendVechileDetails(request);
                Ok(isSuccessfull);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred trying to scan the vin number.", request);
                BadRequest(false);
            }
        }

    }
}