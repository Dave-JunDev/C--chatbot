using MongoDB.Driver;

namespace Interfaces;

public interface ICommonService
{
    Task<T> GetItemByIdAsync<T>(IMongoCollection<T> collection, string id);
    Task<List<T>> GetAll<T>(IMongoCollection<T> collection);
    Task CreateItemAsync<T>(IMongoCollection<T> collection, T entity);
    Task CreateMassiveAsync<T>(IMongoCollection<T> collection, List<T> entities);
    Task UpdateItemAsync<T>(IMongoCollection<T> collection, T entity, string id);
}