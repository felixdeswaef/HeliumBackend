using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Group = System.Text.RegularExpressions.Group;

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

    public Task<Group?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteResult> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ReplaceOneResult> Update(string id, Group group)
    {
        throw new NotImplementedException();
    }

    public Task<Show?> UpdateName(string id, string name)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> AddUser(string id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> RemUser(string id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> AddAdmin(string id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> RemAdmin(string id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> AddShow(string id, Show show)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> RemShow(string id, Show show)
    {
        throw new NotImplementedException();
    }
}