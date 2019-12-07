using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nexmo.Api;
using Nexmo.Api.Request;
using System.Linq;
using VinScanner.Extentions;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Brokers
{
    public class NexmoBroker : INexmoBroker
    {
        private readonly ILogger<NexmoBroker> _logger;
        private readonly Client _NexmoClient = null;

        /// <summary>
        /// Initializes the logger and the Nexmo client
        /// </summary>
        /// <param name="logger"></param>
        public NexmoBroker(ILogger<NexmoBroker> logger, IOptions<Credentials> configuration)
        {
            
            //Takes the API key and secret key from the appSettings file, rather than hardcoding
            _NexmoClient = new Client(new Credentials {
                //Takes the already encrypted value and decrypts 
                ApiKey = Cipher.DecryptString(configuration.Value.ApiKey, Constants.NexmoApiKeyPassKey),
                ApiSecret = Cipher.DecryptString(configuration.Value.ApiSecret, Constants.NexmoApiSecretPassKey),
            });

            _logger = logger;
        }

        /// <summary>
        /// Makes use of the Nexmo Client to send an sms 
        /// </summary>
        /// <param name="to">To whom the message is sent to, with th</param>
        /// <param name="message">The message</param>
        /// <returns></returns>
        public bool Send(string to, string message, string title, string from)
        {
            //todo make values to get from content
            var results = _NexmoClient.SMS.Send(new SMS.SMSRequest
            {
                from = from ?? "VIN Scanner | The Delta Studio",
                to = to,
                text = message,
                title = title ?? "VIN Scanner"
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
