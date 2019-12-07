using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VinScanner.Interfaces;

namespace VinScanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private readonly ILogger<NotificationController> _logger;
        public NotificationController(IEmailService emailService, ISmsService smsService, ILogger<NotificationController> logger)
        {
            _smsService = smsService;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("{to}/{message}")]
        public void SendSms([FromRoute] string to, [FromRoute] string message)
        {
            try
            {
                var isSuccessful = _smsService.Send(to, message);
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
                var isSuccessful = _emailService.Send(to, message);
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