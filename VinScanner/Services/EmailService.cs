using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinScanner.Extensions;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridBroker _sendGridBroker;
        public EmailService(ISendGridBroker sendGridBroker)
        {
            _sendGridBroker = sendGridBroker;
        }

        public async Task<bool> Send(string to, string template)
        {
            //Get Predefined email content from a json file
            var emailContent = JsonFileReader.ReadFile<List<EmailContent>>("EmailContent");
            var emailDetails = emailContent.Find(content => content.Template == template);

            //Sends the email using the SendGrid client
            var response = await _sendGridBroker.SendEmail(new EmailAddress(to), new EmailAddress(emailDetails.From), emailDetails.Message, emailDetails.Subject);
            return response;
        }
    }
}
