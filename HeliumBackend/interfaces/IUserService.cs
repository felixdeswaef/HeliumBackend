using HeliumBackend.models;
using MongoDB.Driver;

namespace HeliumBackend.interfaces;

public interface IUserService
{
    //crud
    Task<User?> Create(User user);

    Task<List<User>> GetAll();
    Task<User?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,User user);
    
    //special
    
}