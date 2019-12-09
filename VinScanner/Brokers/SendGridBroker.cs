using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;
using VinScanner.Extentions;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Brokers
{
    public class SendGridBroker : ISendGridBroker
    {
        private readonly SendGridClient _sendGridClient = null;
        private readonly ILogger<EmailAddress> _logger;

        /// <summary>
        /// Instantiates the send grid client and logger. Gets secuirity key from server's environment variable
        /// </summary>
        /// <param name="logger"></param>
        public SendGridBroker(ILogger<EmailAddress> logger, IConfiguration configurations)
        {
            //Get encrypted key from config
            var sendGridEncryptedApiKey = configurations.GetSection("SendGridApiKey").Value;
            //Decrypt and add to client
            _sendGridClient = new SendGridClient(Cipher.DecryptString(sendGridEncryptedApiKey, Constants.SendGridPassKey));
            _logger = logger;
        }
        
        /// <summary>
        /// Sends and email 
        /// </summary>
        /// <param name="to">The receiver of the email</param>
        /// <param name="message">Message that is sent</param>
        /// <returns></returns>
        public async Task<bool> SendEmail(EmailAddress fromEmailAddress, EmailAddress toEmailAddress, string message, string subject)
        {
            try
            {
                //todo make values to get from content
                var from = fromEmailAddress ?? new EmailAddress("VinScanner@TheDeltaStudio.com", "VinScanner");
                var emailSubject = subject ?? "Vin Scanner | The Delta Studio";
                var email = MailHelper.CreateSingleEmail(from, toEmailAddress, emailSubject, message, message);

                var response = await _sendGridClient.SendEmailAsync(email);
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    _logger.LogError("Send grid could not send the email.", response);
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occurred trying to send an email", toEmailAddress, fromEmailAddress, subject, message);
            }
            return false;
        }
    }
}
