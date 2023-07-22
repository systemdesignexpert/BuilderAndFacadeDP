using System;
using System.Text;

namespace HTTPClient
{
	public class HTTPClientWrapper
	{
		public HTTPClientWrapper()
		{
		}

        public async Task<string> Get(string url)
		{
			HttpRequestMessageBuilder builder = new HttpRequestMessageBuilder();
			builder.WithRequestUri(new Uri(url)).WithMethod(HttpMethod.Get);

			string responseBody;
			using (HttpClient client = new HttpClient())
			{
				var response = await client.SendAsync(builder.Build());
                responseBody = await response.Content.ReadAsStringAsync();
            }

			return responseBody;
		}

        public async Task<string> Post(string url, string body)
        {
            HttpRequestMessageBuilder builder = new HttpRequestMessageBuilder();
            builder.WithRequestUri(new Uri(url))
                .WithMethod(HttpMethod.Post)
                .WithContent(new StringContent(body, Encoding.UTF8, "application/json"));

            string responseBody;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.SendAsync(builder.Build());
                responseBody = await response.Content.ReadAsStringAsync();
            }

            return responseBody;
        }

    }
}

