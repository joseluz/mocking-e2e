using MongoDB.Bson;
using MongoDB.Driver;
using MyStore.Persistence.Documents;
using System.Collections;

namespace MyStore.Persistence.DataStore
{
    public class ProductDataStore : IProductDataStore
    {
        private const string CollectionName = "Products";
        private readonly IMongoCollection<ProductDocument> productCollection;

        public ProductDataStore(IMongoDatabase database)
        {
            productCollection = InitCollection(database);
        }

        private static IMongoCollection<ProductDocument> InitCollection(IMongoDatabase database) => database.GetCollection<ProductDocument>(CollectionName)
                .WithWriteConcern(WriteConcern.WMajority);

        public async Task<IList<ProductDocument>> FindAll()
        {
            var prod = await productCollection.FindAsync(Builders<ProductDocument>.Filter.Empty);
            return prod.ToList();
        }
    }
}
