using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace VinScanner.Interfaces
{
    public interface ISendGridBroker
    {
        /// <summary>
        /// Sends an email via send grid client
        /// </summary>
        /// <param name="fromEmailAddress"> The from email address displayed in the email</param>
        /// <param name="toEmailAddress">To whom the email needs to be send to</param>
        /// <param name="message">The message</param>
        /// <param name="subject">The subject</param>
        /// <returns></returns>
        Task<bool> SendEmail(EmailAddress fromEmailAddress, EmailAddress toEmailAddress, string message, string subject);
    }
}
