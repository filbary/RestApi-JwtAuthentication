using School2.Repositories.Models;

namespace School2.Repositories.Interfaces
{
    public interface IMongoDbRepository<TDocument> where TDocument : IDocument
    {
        public Task<TDocument> FindByIdAsync(string Id);
        public Task<IEnumerable<TDocument>> FindManyByParamAsync(string name, string value);
        public Task<TDocument> FindOneByParamAsync(string name, string value);
        public Task InsertOneAsync(TDocument document);
        public Task InsertManyAsync(ICollection<TDocument> documents);
        public Task<TDocument> ReplaceOne(string Id, TDocument document);
        public Task<TDocument> DeleteOne(string Id);
        public Task<IEnumerable<TDocument>> GetAll();
    }
}
