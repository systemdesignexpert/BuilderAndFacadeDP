using System;
using System.Text.Json;

namespace HTTPClient.RestImplementations
{
	public class WeatherForestCastClientFacade
	{
		public WeatherForestCastClientFacade()
		{
            weatherForecastRestCaller = new HTTPClientWrapper();
            getWeatherForecastEndpoint = weatherForecastEndpoint + "/weatherforecast";

        }

        private HTTPClientWrapper weatherForecastRestCaller;
        private string weatherForecastEndpoint = "https://websocketchatting.azurewebsites.net/";
        private string getWeatherForecastEndpoint;

        public async Task<WeatherForecast> getMaxForecast()
        {
            var response = await weatherForecastRestCaller.Get(getWeatherForecastEndpoint);
            List<WeatherForecast>? forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(response);

            int maxTemp = -100;
            foreach (var forecast in forecasts)
            {
                maxTemp = Math.Max(maxTemp, forecast.temperatureC);
            }
            return new WeatherForecast() { temperatureC = maxTemp, temperatureF = (9 * maxTemp / 5) + 32, };

        }

        public async Task<WeatherForecast> getMinForecast()
        {
            var response = await weatherForecastRestCaller.Get(getWeatherForecastEndpoint);
            List<WeatherForecast>? forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(response);

            int minTemp = 100;
            foreach (var forecast in forecasts)
            {
                minTemp = Math.Min(minTemp, forecast.temperatureC);
            }
            return new WeatherForecast() { temperatureC = minTemp, temperatureF = (9 * minTemp / 5) + 32, };
        }

        public async Task<WeatherForecast> getAvgForecast()
        {
            var response = await weatherForecastRestCaller.Get(getWeatherForecastEndpoint);
            List<WeatherForecast>? forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(response);

            int sumTemp = 0;
            foreach (var forecast in forecasts)
            {
                sumTemp += forecast.temperatureC;
            }
            int avgTemp = (int)(sumTemp / forecasts.Count);
            WeatherForecast newForecast = new WeatherForecast()
            {
                summary = "MILD",
                temperatureC = avgTemp,
                temperatureF = (9 * avgTemp / 5) + 32,
                date = "2023-07-25"
            };
            return newForecast;
        }

    }
}

