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
            var prods = await productDataStore.FindAll();
            return prods.Select(p => new Product()
            {
                Name = p.Name,
                Key = p.Key,
                Id = p.Id.ToString(),
            }).ToList();
        }
    }
}
