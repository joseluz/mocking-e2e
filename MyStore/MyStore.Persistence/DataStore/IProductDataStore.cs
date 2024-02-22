using MyStore.Persistence.Documents;

namespace MyStore.Persistence.DataStore
{
    public interface IProductDataStore
    {
        Task<IList<ProductDocument>> FindAll();
    }
}
