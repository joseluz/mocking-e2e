using MyStore.Application.Connectors;
using MyStore.Application.Model;
using MyStore.Application.Repositories;

namespace MyStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IFreeMarketConnector freeMarketConnector;

        public ProductService(IProductRepository productRepository, IFreeMarketConnector freeMarketConnector)
        {
            this.productRepository = productRepository;
            this.freeMarketConnector = freeMarketConnector;
        }

        public async Task<IList<Product>> FindAll()
        {
            var products = await productRepository.FindAll();
            await EnrichProducts(products);
            return products;
        }

        private async Task EnrichProducts(IList<Product> products)
        {
            var productIds = products.Select(s => s.Key);
            var productsPriceTable = (await freeMarketConnector.SearchPriceTableFor(productIds))
                .Where(p => p.CurrentValue > 0)
                .DistinctBy(p => p.Key)
                .ToDictionary(p => p.Key);
            foreach (var product in products)
            {
                if (productsPriceTable.TryGetValue(product.Key, out var productPriceItem))
                {
                    product.CurrentValue = productPriceItem.CurrentValue;
                }
            }
        }
    }
}
