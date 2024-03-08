using HeliumBackend.models;
using MongoDB.Driver;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.interfaces;

public interface IsessionService
{ //session also handles recording durations
    //crud
    Task<Session?> Create(Session ses);
    
    Task<Session?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Session ses);
    //special
    Task<List<Session>> GetShowSessions(string id);
    
    


    
    

}