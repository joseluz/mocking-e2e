using MyStore.Application.Connectors;
using MyStore.Application.Model;

namespace FreeMarket.Integration
{
    public class FreeMarketConnector : IFreeMarketConnector
    {
        private readonly HttpClient httpClient;

        public FreeMarketConnector(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductPriceItem>> SearchPriceTableFor(IEnumerable<string> keys)
        {
            return keys.Select(k => new ProductPriceItem() { Id = k, CurrentValue = (decimal)Math.Round(new Random().NextDouble() * 200, 2) });
        }
    }
}
