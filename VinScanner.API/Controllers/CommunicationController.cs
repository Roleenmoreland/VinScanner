using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinScanner.API.Interfaces;
using VinScanner.API.Services;

namespace VinScanner.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService<EmailService> _emailCommunicationService;
        private readonly ICommunicationService<SmsService> _smsCommunicationService;

        public CommunicationController(ICommunicationService<SmsService> smsCommunicationService, ICommunicationService<EmailService> emailCommunicationService)
        {
            _smsCommunicationService = smsCommunicationService;
            _emailCommunicationService = emailCommunicationService;
        }

        //[HttpPost]
        [HttpPost("{to}/{message}")]
        public void SendSms([FromRoute] string to, [FromRoute] string message)
        {
            _smsCommunicationService.Send(to, message);
        }

        [HttpPost("{to}/{message}")]
        public void SendEmail([FromRoute] string to, [FromRoute] string message)
        {
            _emailCommunicationService.Send(to, message);

        }
    }
}