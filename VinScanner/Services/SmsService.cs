using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nexmo.Api;
using Nexmo.Api.Request;
using System.Linq;
using VinScanner.View.Interfaces;

namespace VinScanner.View.Services
{
    public class SmsService : ICommunicationService<SmsService>
    {
        private readonly ILogger<SmsService> _logger;
        private readonly Client _client = null;

        /// <summary>
        /// Initializes the logger and the Nexmo client
        /// </summary>
        /// <param name="logger"></param>
        public SmsService(ILogger<SmsService> logger, IOptions<Credentials> configuration)
        {
            //Takes the API key and secret key from the appSettings file, rather than hardcoding
            _client = new Client(configuration.Value);
            _logger = logger;
        }

        /// <summary>
        /// Makes use of the Nexmo Client to send an sms 
        /// </summary>
        /// <param name="to">To whom the message is sent to, with th</param>
        /// <param name="message">The message</param>
        /// <returns></returns>
        public bool Send(string to, string message)
        {
            //todo make values to get from content
            var results = _client.SMS.Send(new SMS.SMSRequest
            {
                from = "VIN Scanner | The Delta Studio",
                to = to,
                text = message,
                title = "VIN Scanner"
            });
            var hasErrors = results?.messages?.Any(x => x.error_text != null) ?? false;

            if (hasErrors)
            {
                _logger.LogError("Error occurred trying to send a SMS.", results);
                return false;
            }
            return true;
        }
    }
}
