using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeliumBackend.services;

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _UserCollection;
    //----
    public UserService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _UserCollection = database.GetCollection<User>(dbSettings.Value.UsersCollectionName);
    }
    public async Task<User?> Create(User user)
    {
        user.Id = ObjectId.GenerateNewId().ToString();
        await _UserCollection.InsertOneAsync(user);
        return user;
    }

    public async Task<List<User>> GetAll()
    {
        return await _UserCollection.Find(s => true).ToListAsync();
    }

    public async Task<User?> GetById(string id)
    {
        return await _UserCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public async Task<DeleteResult> Delete(string id)
    {
        return await _UserCollection.DeleteOneAsync(u => u.Id == id);
    }

    public async Task<ReplaceOneResult> Update(string id, User user)
    {
        return await _UserCollection.ReplaceOneAsync(u => u.Id == id,user);

    }
}
