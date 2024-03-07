using HeliumBackend.models;
using MongoDB.Driver;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.interfaces;

public interface ICueService
{
    Task<Cue?> Create(Cue cue, CueCard card);

    Task<Cue?> GetById(string id);
    
    
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Cue cue);

    Task<UpdateResult> ChangeCueTag(string id, Tag tag);
    Task<UpdateResult> ChangeCueText(string id, Tag tag);
    Task<UpdateResult> ChangeCueColor(string id, Tag tag);
    //Task<UpdateResult> ChangeCueDuration(string id, Tag tag);
    //Task<UpdateResult> AddCueRecordedTime(string id, Duration duration);
    
    
}

public interface ICueCardService
{
    
    Task<CueCard?> Create(CueCard cueCard,Show show);

    Task<CueCard?> GetById(string id);
    
    Task<List<Cue>> GetCuesFromCardId(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Cue cue);
    
}

public interface ITagService
{
    //crud
    Task<Tag?> Create(Tag tag);
    
    Task<Tag?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Cue cue);
    //special
    Task<List<Tag>> GetPublicTags();
    Task<List<Tag>> GetShowTags();
    Task<List<Tag>> GetTags();
    
    

}