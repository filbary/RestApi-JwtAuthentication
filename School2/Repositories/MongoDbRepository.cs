using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using School2.ConfigModels;
using School2.Helpers;
using School2.Repositories.Interfaces;
using School2.Repositories.Models;

namespace School2.Repositories
{
    public class MongoDbRepository<TDocument> : IMongoDbRepository<TDocument> where TDocument : IDocument
    {
        private protected readonly IMongoCollection<TDocument> Collection;
        public MongoDbRepository(IOptions<MongoSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            Collection = database.GetCollection<TDocument>(GetDocumentName(typeof(TDocument)));
        }

        private protected string GetDocumentName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
        }

        public virtual async Task<TDocument> FindByIdAsync(string Id)
        {
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, new ObjectId(Id));
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TDocument>> FindManyByParamAsync(string name, string value)
        {
            var filter = Builders<TDocument>.Filter.Eq(name, value);
            return (await Collection.FindAsync(filter)).ToEnumerable();
        }

        public virtual async Task<TDocument> FindOneByParamAsync(string name, string value)
        {
            var filter = Builders<TDocument>.Filter.Eq(name, value);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public virtual async Task InsertOneAsync(TDocument document)
        {
            await Collection.InsertOneAsync(document);
        }

        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await Collection.InsertManyAsync(documents);
        }

        public virtual async Task<TDocument> ReplaceOne(string Id, TDocument document)
        {
            var objectId = new ObjectId(Id);
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
            return await Collection.FindOneAndReplaceAsync(filter, document);
        }

        public virtual async Task<TDocument> DeleteOne(string Id)
        {
            var objectId = new ObjectId(Id);
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, objectId);
            var result = await Collection.FindOneAndDeleteAsync(filter);
            return result;
        }

        public virtual async Task<IEnumerable<TDocument>> GetAll()
        {
            var result = (await Collection.FindAsync(Builders<TDocument>.Filter.Empty)).ToEnumerable();
            return result;
        }
    }
}
