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

        public bool Send(int mobileNumber, string message, string title = "", string from = "")
        {
            //Sends the SMS using the Nexmo client
            var response = _nexmoBroker.SendSms(mobileNumber, message, title, from);
            return response;
        }

        public bool Send(int mobileNumber, string template, string messagePlaceHolders)
        {
            //Get Predefined sms content from a json file
            var smsContent = JsonFileReader.ReadFile<List<SmsContent>>("SmsContent");
            var smsDetails = smsContent.Find(content => content.Template == template);

            var message = smsDetails.Message;
            //Add the place holders in the message
            if (!string.IsNullOrWhiteSpace(messagePlaceHolders))
            {
                message = string.Format(smsDetails.Message, messagePlaceHolders);
            }

            //Sends the SMS using the Nexmo client
            var response = _nexmoBroker.SendSms(mobileNumber, message, smsDetails.Title, smsDetails.From);
            return response;
        }
    }
}
