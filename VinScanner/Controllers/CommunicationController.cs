using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VinScanner.View.Interfaces;
using VinScanner.View.Services;

namespace VinScanner.View.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService<EmailService> _emailCommunicationService;
        private readonly ICommunicationService<SmsService> _smsCommunicationService;
        private readonly ILogger<CommunicationController> _logger;
        public CommunicationController(ICommunicationService<SmsService> smsCommunicationService, ICommunicationService<EmailService> emailCommunicationService, ILogger<CommunicationController> logger)
        {
            _smsCommunicationService = smsCommunicationService;
            _emailCommunicationService = emailCommunicationService;
            _logger = logger;
        }

        [HttpPost("{to}/{message}")]
        public void SendSms([FromRoute] string to, [FromRoute] string message)
        {
            try
            {
                var isSuccessful = _smsCommunicationService.Send(to, message);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to perform and SMS request.", e, to, message);
                BadRequest();
            }
        }

        [HttpPost("{to}/{message}")]
        public void SendEmail([FromRoute] string to, [FromRoute] string message)
        {
            try
            {
                var isSuccessful = _emailCommunicationService.Send(to, message);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to send and email request.", e, to, message);
                BadRequest();
            }
        }
    }
}