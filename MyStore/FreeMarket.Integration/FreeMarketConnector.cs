using MyStore.Application.Connectors;
using MyStore.Application.Model;

namespace FreeMarket.Integration
{
    public class FreeMarketConnector : IFreeMarketConnector
    {
        public async Task<IEnumerable<ProductPriceItem>> SearchPriceTableFor(IEnumerable<string> keys)
        {
            return keys.Select(k => new ProductPriceItem() { Id = k, CurrentValue = (decimal)Math.Round(new Random().NextDouble() * 200, 2) });
        }
    }
}
