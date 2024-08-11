using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketDataApi.Services
{
    public class DataApi
    {
        private readonly HttpClient _client;

        public DataApi()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetMarketDataAsync(string symbol)
        {
            var requestUri = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=IBM&apikey=demo";

            using (var response = await _client.GetAsync(requestUri))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
