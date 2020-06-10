using Domain.Models;
using System.Collections.Generic;

namespace Domain
{
    public interface IWeatherForecaster
    {
        IEnumerable<WeatherForecast> GetForecast();
    }
}