using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyStore.Persistence.Documents
{
    public class ProductDocument
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
