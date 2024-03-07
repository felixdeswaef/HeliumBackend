using HeliumBackend.models;
using MongoDB.Driver;

namespace HeliumBackend.interfaces;

public interface IShowService
{
    //crud
    Task<Show?> Create(Show show);
    
    Task<Show?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Show show);
    
    //special
    Task<UpdateResult> UpdateName(string id, string name);
    
    Task<UpdateResult> AddCard(string id, CueCard cueCard);
    Task<UpdateResult> RemCard(string id, CueCard cueCard);
    
    Task<UpdateResult> AddOwner(string id, User user);
    Task<UpdateResult> RemOwner(string id, User user);
    
    
    
    
}