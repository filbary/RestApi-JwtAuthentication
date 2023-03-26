using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace School2.Repositories.Models
{
    public abstract class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
