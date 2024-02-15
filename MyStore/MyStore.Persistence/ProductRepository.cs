using MyStore.Application.Model;
using MyStore.Application.Repositories;

namespace MyStore.Persistence
{
    public class ProductRepository : IProductRepository
    {
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
