using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace VinScanner.Interfaces
{
    public interface ISendGridBroker
    {
        Task<bool> Send(EmailAddress fromEmailAddress, EmailAddress toEmailAddress, string message, string subject);
    }
}
