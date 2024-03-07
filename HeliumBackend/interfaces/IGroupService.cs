using HeliumBackend.models;
using MongoDB.Driver;
using Group = HeliumBackend.models.Group;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.interfaces;

public interface IGroupService
{
    //crud
    Task<Group?> Create(Group group);
    
    Task<Group?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Group group);
    
    //special
    Task<UpdateResult> UpdateName(string id, string name);
    
    Task<UpdateResult> AddUser(string id,User user);
    Task<UpdateResult> RemUser(string id,User user);
    
    Task<UpdateResult> AddAdmin(string id,User user);
    Task<UpdateResult> RemAdmin(string id,User user);
    
    Task<UpdateResult> AddShow(string id,Show show);
    Task<UpdateResult> RemShow(string id,Show show);
}