using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.UseCases.WeatherForecast
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecaster _forecaster;

        public WeatherForecastController(IWeatherForecaster forecaster)
        {
            _forecaster = forecaster;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.WeatherForecast> Get()
        {
            return _forecaster.GetForecast();
        }
    }
}
