using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;
using VinScanner.View.Interfaces;

namespace VinScanner.Services
{
    public class EmailService : ICommunicationService<EmailService>
    {
        private readonly SendGridClient _sendGridClient = null;
        private readonly ILogger<EmailAddress> _logger;

        /// <summary>
        /// Instantiates the send grid client and logger. Gets secuirity key from server's environment variable
        /// </summary>
        /// <param name="logger"></param>
        public EmailService(ILogger<EmailAddress> logger)
        {
            var apiKey = Environment.GetEnvironmentVariable("API-KEY");
            _sendGridClient = new SendGridClient(apiKey);
            _logger = logger;
        }
        
        /// <summary>
        /// Sends and email
        /// </summary>
        /// <param name="to">The receiver of the email</param>
        /// <param name="message">Message that is sent</param>
        /// <returns></returns>
        public bool Send(string to, string message)
        {
            try
            {
                //todo make values to get from content
                var from = new EmailAddress("VinScanner@TheDeltaStudio.com", "VinScanner");
                var subject = "Vin Scanner | The Delta Studio";
                var msg = MailHelper.CreateSingleEmail(from, new EmailAddress(to), subject, message, message);

                //Method can be chnaged to be async to avoid the below
                var response = Task.Run(() => _sendGridClient.SendEmailAsync(msg)).Result;
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    _logger.LogError("Send grid could not send the email.", response);
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred trying to send an email", to, message);
            }
            return false;
        }
    }
}
