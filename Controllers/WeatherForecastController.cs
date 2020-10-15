using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatheFrorecastBelfast;

namespace WeatheForecastBelfast.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly string apiUrl = "https://www.metaweather.com/api/location/";
        public readonly string apiParamSearch = "search/?query=";
        public readonly string city = "Belfast";

        static HttpClient client = new HttpClient();


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<LocationDetails>> GetAsync()
        {
            var locationDetails = new List<LocationDetails>();

            HttpResponseMessage response = await client.GetAsync(apiUrl + apiParamSearch + city);
            if (response.IsSuccessStatusCode)
            {
                var locations = await response.Content.ReadAsAsync<IEnumerable<Location>>();

                var location = locations.ToList().FirstOrDefault();

                // 5 days
                for (var i = 0; i < 5; i++)
                {
                    var date = DateTime.Now.AddDays(i).ToString("yyyy/MM/dd");
                    HttpResponseMessage responseDetails = await client.GetAsync(apiUrl + location.woeid + "/" + date);
                    if (responseDetails.IsSuccessStatusCode)
                    {
                        var responseDetailsTmp = await responseDetails.Content.ReadAsAsync<IEnumerable<LocationDetails>>();
                        locationDetails.Add(responseDetailsTmp.FirstOrDefault());
                    }
                }
            }

            return locationDetails;
        }
    }
}
