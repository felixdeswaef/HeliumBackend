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

    Task<UpdateResult> AddCueTag(string id, Tag tag);
    Task<UpdateResult> RemCueTag(string id, Tag tag);
    Task<UpdateResult> ChangeCueText(string id, string text);
    Task<UpdateResult> ChangeCuePos(string id, int pos);
    //Task<UpdateResult> ChangeCueDuration(string id, Tag tag);
    //Task<UpdateResult> AddCueRecordedTime(string id, Duration duration);
    
    
}

public interface ICueCardService
{
    
    Task<CueCard?> Create(CueCard cueCard,Show show);

    Task<CueCard?> GetById(string id);
    
    List<string> GetCuesFromCardId(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,CueCard cueCard);
    
}

public interface ITagService
{
    //crud
    Task<Tag?> Create(Tag tag);
    
    Task<Tag?> GetById(string id);
    
    Task<DeleteResult> Delete(string id);
    
    Task<ReplaceOneResult> Update(string id,Tag tag);
    //special
    Task<List<Tag>> GetPublicTags();
    Task<List<Tag>> GetShowTags(string id);
    Task<List<Tag>> GetTags();
    
    

}