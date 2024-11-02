using C__chatbot.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Services;

public class CommonService : ICommonService
{
    public CommonService() { }
    public async Task<T> GetItemByIdAsync<T>(IMongoCollection<T> collection, string id)
    {
        var item = await collection.Find($"{{ _id: ObjectId('{id}') }}").FirstAsync();
        return item ?? default!;
    }
    public async Task<List<T>> GetAll<T>(IMongoCollection<T> collection)
        => await collection.AsQueryable().ToListAsync();
    public async Task CreateItemAsync<T>(IMongoCollection<T> collection, T  entity) 
        => await collection.InsertOneAsync(entity);
    public async Task CreateMassiveAsync<T>(IMongoCollection<T> collection, List<T> entities)
        => await collection.InsertManyAsync(entities);

    public async Task UpdateItemAsync<T>(IMongoCollection<T> collection, T entity, string id)
        => await collection.ReplaceOneAsync($"{{ _id: ObjectId('{id}') }}", entity);
}