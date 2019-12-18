using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VinScanner.Extentions;
using VinScanner.Interfaces;
using VinScanner.Models;

namespace VinScanner.Brokers
{
    public class NpTrackerBroker : INpTrackerBroker
    {
        private readonly string BaseURL;
        private readonly string ApiKey;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<NpTrackerBroker> _logger;

        public NpTrackerBroker(IOptions<NpTrackerSettings> configuration, IHttpClientFactory httpClientFactory,
            ILogger<NpTrackerBroker> logger)
        {
            ApiKey = Cipher.DecryptString(configuration.Value.ApiKey, Constants.NpTrackerPassKey);
            BaseURL = configuration.Value.BaseURL;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Vehicle Check Report based on Registration number or VIN
        /// This endpoint are used to provide details on a vehicle based on its VIN or registration number.
        /// </summary>
        /// <param name="vinNumber">The vechile vin number</param>
        public async Task<VechileCheckReportResponse> VechileCheckReport(string vinNumber)
        {
            var client =_httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{BaseURL}?token={ApiKey}&vinregs={vinNumber}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<VechileCheckReportResponse>(await response.Content.ReadAsStringAsync());
            }

            _logger.LogError("Could not retrieve the vechile check report", response);

            throw new Exception($"Could not retrieve the data for this vin number: {vinNumber}.");
        }
    }
}
