using FreeMarket.Integration.Resources;
using MyStore.Application.Connectors;
using MyStore.Application.Model;
using System.Net.Http.Json;

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
            var priceItems = new List<ProductPriceItem>();
            foreach (string key in keys.Order())
            {
                var url = $"/products/{key}/price";
                try
                {

                    var item = await httpClient.GetFromJsonAsync<PriceItemResource>(url);
                    if (item != null)
                    {
                        priceItems.Add(item.ToPriceItem());
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return priceItems;
        }
    }
}
