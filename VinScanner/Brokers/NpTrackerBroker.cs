using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Brokers
{
    public class NpTrackerBroker : INpTrackerBroker
    {
        private readonly string _npTrackerBaseURl;
        private readonly IHttpClientFactory _httpClientFactory;

        public NpTrackerBroker(IConfiguration configurations, IHttpClientFactory httpClientFactory)
        {
            _npTrackerBaseURl = configurations.GetSection("NpTrackerBaseUrl").Value;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Vehicle Check Report based on Registration number or VIN
        /// This endpoint are used to provide details on a vehicle based on its VIN or registration number.
        /// </summary>
        /// <param name="vinNumber">The vechile vin number</param>
        public async Task<VechileCheckReportResponse> VechileCheckReport(string vinNumber)
        {
            var token = "mysecurityToken";
            
            var client =_httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_npTrackerBaseURl}?token={token}&vinregs={vinNumber}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<VechileCheckReportResponse>(await response.Content.ReadAsStringAsync());
            }
            //todo log error

            throw new Exception($"Could not retrieve the data for this vin number: {vinNumber}.");
        }
    }
}
