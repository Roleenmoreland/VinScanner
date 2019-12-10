using VinScanner.Interfaces;
using VinScanner.Models;
using VinScanner.Extensions;
using System.Collections.Generic;

namespace VinScanner.Services
{
    public class SmsService : ISmsService
    {
        private readonly INexmoBroker _nexmoBroker;
        public SmsService(INexmoBroker nexmoBroker)
        {
            _nexmoBroker = nexmoBroker;
        }

        public bool Send(string mobileNumber, string message, string title = "", string from = "")
        {
            //Sends the SMS using the Nexmo client
            var response = _nexmoBroker.SendSms(mobileNumber, message, title, from);
            return response;
        }

        public bool Send(string mobileNumber, string template)
        {
            //Get Predefined sms content from a json file
            var smsContent = JsonFileReader.ReadFile<List<SmsContent>>("SmsContent");
            var smsDetails = smsContent.Find(content => content.Template == template);
            
            //Sends the SMS using the Nexmo client
            var response = _nexmoBroker.SendSms(mobileNumber, smsDetails.Message, smsDetails.Title, smsDetails.From);
            return response;
        }
    }
}
