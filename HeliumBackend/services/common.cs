using HeliumBackend.models;
using MongoDB.Driver;

namespace HeliumBackend.services;

public class common 
{
    public static async Task<UpdateResult> RemUser<T>(IMongoCollection<T> _col,string id,string field , User user)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        var update = Builders<T>.Update.Pull(field, user.Id);
        return await _col.UpdateOneAsync(filter, update);
    }
    public static async Task<UpdateResult> AddUser<T>(IMongoCollection<T> _col,string id,string field , User user)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        var update = Builders<T>.Update.Push(field, user.Id);
        return await _col.UpdateOneAsync(filter, update);
    }
    
    public static async Task<UpdateResult> RemList<T>(IMongoCollection<T> _col,string id,string field , string elementId)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        var update = Builders<T>.Update.Pull(field, elementId);
        return await _col.UpdateOneAsync(filter, update);
    }
    public static async Task<UpdateResult> AddList<T>(IMongoCollection<T> _col,string id,string field , string elementId)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        var update = Builders<T>.Update.Push(field, elementId);
        return await _col.UpdateOneAsync(filter, update);
    }
    
}