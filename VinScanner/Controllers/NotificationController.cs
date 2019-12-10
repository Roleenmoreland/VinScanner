using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VinScanner.Interfaces;
using VinScanner.Models;

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

        /// <summary>
        /// Sends an SMS to the provided number and message.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost()]
        public void SendSms([FromBody]SendSmsRequest request)
        {
            try
            {
                var isSuccessful = _smsService.Send(request.To, request.Message, request.Title, request.From);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to perform and SMS request.", e, request);
                BadRequest();
            }
        }
        /// <summary>
        /// Sends an SMS to the provided number and message will be determined by the pre-defined message templates
        /// </summary>
        /// <param name="to"></param>
        /// <param name="template"></param>
        [HttpPost("{to}/{template}")]
        public void SendSms([FromRoute] string to, [FromRoute] string template)
        {
            try
            {
                var isSuccessful = _smsService.Send(to, template);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to perform and SMS request.", e, to, template);
                BadRequest("test");
            }
        }

        [HttpPost("{to}/{template}")]
        public async Task SendEmail([FromRoute] string to, [FromRoute] string template)
        {
            try
            {
                var isSuccessful = await _emailService.Send(to, template);
                Ok(isSuccessful);
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error occurred trying to send and email request.", e, to, template);
                BadRequest();
            }
        }
    }
}