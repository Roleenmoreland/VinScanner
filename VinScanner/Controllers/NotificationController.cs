using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VinScanner.Interfaces;
using VinScanner.Services;

namespace VinScanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ICommunicationService<SendGridBroker> _emailCommunicationService;
        private readonly ICommunicationService<NexmoBroker> _smsCommunicationService;
        private readonly ILogger<NotificationController> _logger;
        public NotificationController(ICommunicationService<NexmoBroker> smsCommunicationService, ICommunicationService<SendGridBroker> emailCommunicationService, ILogger<NotificationController> logger)
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