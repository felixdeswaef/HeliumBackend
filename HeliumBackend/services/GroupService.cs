using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Group = HeliumBackend.models.Group;
namespace HeliumBackend.services;

public class GroupService : IGroupService
{
    private readonly IMongoCollection<Group> _GroupCollection;

    public GroupService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _GroupCollection = database.GetCollection<Group>(dbSettings.Value.GroupsCollectionName);
    }
    public async Task<Group?> Create(Group group)
    {
        group.Id = ObjectId.GenerateNewId().ToString();
        await _GroupCollection.InsertOneAsync(group);
        return group;
    }

    public async Task<Group?> GetById(string id)
    {
        return await _GroupCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }

    public Task<DeleteResult> Delete(string id)
    {
        return common.Delete<Group>(_GroupCollection, id);
    }

    public Task<ReplaceOneResult> Update(string id, Group group)
    {
        return common.Update<Group>(_GroupCollection, id,group);

    }

    public Task<UpdateResult> UpdateName(string id, string name)
    {
        return common.ChangeField<Group,string>(_GroupCollection, id,"GroupName",name);
    }

    public async Task<UpdateResult> AddUser(string id, User user)
    {
        return await common.AddUser<Group>(_GroupCollection, id, "Users", user);    

    }

    public async Task<UpdateResult> RemUser(string id, User user)
    {
        return await common.RemUser<Group>(_GroupCollection, id, "Users", user);
    }

    public async Task<UpdateResult> AddAdmin(string id, User user)
    {
        return await common.AddUser<Group>(_GroupCollection, id, "Owners", user);    
    }

    public async Task<UpdateResult> RemAdmin(string id, User user)
    {
        return await common.RemUser<Group>(_GroupCollection, id, "Owners", user);
    }

    public async Task<UpdateResult> AddShow(string id, Show show)
    {
        return await common.AddList<Group>(_GroupCollection, id, "Shows", show.Id);
    }

    public async Task<UpdateResult> RemShow(string id, Show show)
    {
        return await common.RemList<Group>(_GroupCollection, id, "Shows", show.Id);
    }
}