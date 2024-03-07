using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeliumBackend.services;

public class ShowService : IShowService
{
    private readonly IMongoCollection<Show> _ShowCollection;
    //----
    public ShowService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _ShowCollection = database.GetCollection<Show>(dbSettings.Value.ShowsCollectionName);
    }
    public async Task<Show?> Create(Show show)
    {
        show.Id = ObjectId.GenerateNewId().ToString();
        await _ShowCollection.InsertOneAsync(show);
        return show;
    }

    public async Task<Show?> GetById(string id)
    {
        return await _ShowCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
        
    }

    public async Task<DeleteResult> Delete(string id)
    {
        return await _ShowCollection.DeleteOneAsync(s => s.Id == id);
    }

    public async Task<ReplaceOneResult> Update(string id, Show show)
    {
        return await _ShowCollection.ReplaceOneAsync(s => s.Id == id,show);
    }

    public async Task<UpdateResult> UpdateName(string id, string name)
    {
        var update = Builders<Show>.Update.Set(s => s.ShowName, name);
        return await _ShowCollection.UpdateOneAsync(s => s.Id == id, update);
        
        

    }

    public async Task<UpdateResult> AddCard(string id, CueCard cueCard)
    {
        return await common.AddList<Show>(_ShowCollection, id, "Cards", cueCard.Id);
    }

    public async Task<UpdateResult> RemCard(string id, CueCard cueCard)
    {
        return await common.RemList<Show>(_ShowCollection, id, "Cards", cueCard.Id);
    }

    public async Task<UpdateResult> AddOwner(string id, User user)
    {
        return await common.AddUser<Show>(_ShowCollection, id, "Owners", user);    }

    public async Task<UpdateResult> RemOwner(string id, User user)
    {
        return await common.RemUser<Show>(_ShowCollection, id, "Owners", user);
        
    }
}