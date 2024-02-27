using MyStore.Application.Model;

namespace FreeMarket.Integration.Resources
{
    public class PriceItemResource
    {
        public string? Id { get; set; }
        public decimal Price { get; set; }

        public ProductPriceItem ToPriceItem()
        {
            return new ProductPriceItem()
            {
                Key = Id ?? "",
                CurrentValue = Price,
            };
        }
    }
}
