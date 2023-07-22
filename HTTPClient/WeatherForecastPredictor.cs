using System;
using System.Text.Json;
using HTTPClient.RestImplementations;

namespace HTTPClient
{
	public class WeatherForecastPredictor
	{

		private WeatherForestCastClientFacade facade;
        public WeatherForecastPredictor()
		{
			facade = new WeatherForestCastClientFacade();

        }

		public async Task<int> getAvgTemp()
		{
            var newForecast = await facade.getAvgForecast();
			return newForecast.temperatureC;

		}

        

        public async Task<int> getMinTemp()
		{

            var newForecast = await facade.getMinForecast();
            return newForecast.temperatureC;

        }

        public async Task<int> getMaxTemp()
        {

            var newForecast = await facade.getMaxForecast();
            return newForecast.temperatureC;
        }

        public async Task<int> getTomorrowPrediction()
        {

            int avg = await getAvgTemp();
            int min = await getMinTemp();
            int max = await getMaxTemp();

            return Math.Abs((max + min) / 2 - avg) + avg;
        }

    }
}

