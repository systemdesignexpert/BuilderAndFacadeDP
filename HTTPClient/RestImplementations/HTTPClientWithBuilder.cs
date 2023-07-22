using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HTTPClientWithBuilder
{
    public async Task CallRestEndpoint2()
    {
        var builder = new HttpRequestMessageBuilder()
            .WithMethod(HttpMethod.Post)
            .WithRequestUri(new Uri("https://websocketchatting.azurewebsites.net/weatherforecast/addforecast"))
            .WithContent(new StringContent(
                "{\"Date\":\"2023-05-01\",\"TemperatureC\":\"55\",\"Summary\":\"Hottest\"}",
                Encoding.UTF8,
                "application/json"
                ));

        var request = builder.Build();


        var httpClient = new HttpClient();
        
        var response = await httpClient.SendAsync(request);

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

    public async Task CallRestEndpoint1()
    {
        var builder = new HttpRequestMessageBuilder()
            .WithMethod(HttpMethod.Get)
            .WithRequestUri(new Uri("https://websocketchatting.azurewebsites.net/weatherforecast"));
            

        var request = builder.Build();


        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.SendAsync(request);

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
