using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VinScanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        [HttpGet()]
        public void Get([FromHeader] string username)
        {
            try
            {
                //1. Do windows or some type of authentication 
                //2. Get a list of all the clients
                //var isSuccessful = _smsService.Send(to, message);
                Ok();
            }
            catch (Exception e)
            {
                //_logger.LogError("Error occurred trying to perform and SMS request.", e, to, message);
                BadRequest();
            }
        }

    }
}