using MyStore.Application.Model;
using MyStore.Application.Repositories;
using MyStore.Persistence.DataStore;

namespace MyStore.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDataStore productDataStore;

        public ProductRepository(IProductDataStore productDataStore)
        {
            this.productDataStore = productDataStore;
        }

        public async Task<IList<Product>> FindAll()
        {
            return new List<Product>()
            {
                new()
                {
                    Id="P1",
                    Name="Product 1"
                },
                new()
                {
                    Id="P2",
                    Name="Product 2"
                }
            };
        }
    }
}
