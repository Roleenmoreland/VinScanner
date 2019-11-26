using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using VinScanner.API.Interfaces;
using System.Net;

namespace VinScanner.API.Services
{
    public class EmailService : ICommunicationService<EmailService>
    {
        public bool Send(string to, string message)
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress("VinScanner@TheDeltaStudio.com", "VinScanner"),
                Body = message,
                Subject = "The Delta Studio",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(new MailAddress(to));
            SmtpClient(mailMessage);
            return true;
        }

        private void SmtpClient(MailMessage message)
        {
            try
            {
                var smtpClient = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("Vin.ScannerApp@gmail.com", "vinScanner1@"),
                    EnableSsl = true,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    //Timeout = 120,
                };

                smtpClient.Send(message);
                smtpClient.Dispose();

            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
