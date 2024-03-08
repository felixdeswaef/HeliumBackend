using HeliumBackend.models;
using MongoDB.Driver;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.interfaces;

public interface IDurationService
{
    // duration 
    Task<Duration?> Create(Duration Dur);
    
    Task<Duration?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Duration Dur);
    //special
    Task<List<Duration>> GetCueDurations(string id);
    Task<List<Duration>> GetSessionDurations(string id);
}