using System;
using System.Net.Http;
using System.Text;

namespace HTTPClient
{
    public class HTTPGeneralClient
    {
        public HTTPGeneralClient()
        {
        }

        public async Task<string> GetCall()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.Send(request);
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public async Task CallRestEndpoint1()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://websocketchatting.azurewebsites.net/weatherforecast"));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            Console.WriteLine("Response:");
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Headers:");
            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            Console.WriteLine();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Body: {responseBody}");

        }

        public async Task CallRestEndpoint2()
        {

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://websocketchatting.azurewebsites.net/weatherforecast/addforecast"));
            request.Content = new StringContent(
                "{\"Date\":\"2023-05-01\",\"TemperatureC\":\"55\",\"Summary\":\"Hottest\"}",
                Encoding.UTF8,
                "application/json"
                );


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            Console.WriteLine("Response:");
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Headers:");
            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            Console.WriteLine();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Body: {responseBody}");

        }
    }
}

