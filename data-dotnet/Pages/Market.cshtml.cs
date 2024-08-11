using MarketDataApi.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Microsoft.AspNetCore.Mvc.Rendering
{}

namespace Market.Pages
{
    public class MarketModel : PageModel
    {
        private readonly ILogger<MarketModel> _logger;
        private readonly DataApi _dataApi;

        public MarketModel(ILogger<MarketModel> logger, DataApi dataApi)
        {
            _logger = logger;
            _dataApi = dataApi;
        }

        public string MarketDataJson { get; set; }

        public async Task OnGetAsync()
        {
            var symbol = "SPX"; // Example symbol
            MarketDataJson = await _dataApi.GetMarketDataAsync(symbol);
            _logger.LogInformation("Market data fetched successfully.");
            _logger.LogInformation($"Fetched Data {MarketDataJson}");
        }
    }
}