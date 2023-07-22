// See https://aka.ms/new-console-template for more information
using HTTPClient;

Console.WriteLine("Hello, World!");

WeatherForecastPredictor predictor = new WeatherForecastPredictor();
int temp = await predictor.getTomorrowPrediction();
Console.WriteLine(temp);

//WeatherForecastPredictor predictor = new WeatherForecastPredictor();
//int avg = await predictor.getTomorrowPrediction();
//Console.WriteLine(avg);



