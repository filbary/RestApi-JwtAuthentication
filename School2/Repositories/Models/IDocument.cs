using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace School2.Repositories.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; }
    }
}
