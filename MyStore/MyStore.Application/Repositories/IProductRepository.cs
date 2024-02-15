using MyStore.Application.Model;

namespace MyStore.Application.Repositories
{
    public interface IProductRepository
    {
        Task<IList<Product>> FindAll();
    }
}
