using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.services;

public class CueService : ICueService
{
       
    private readonly IMongoCollection<Cue> _CueCollection;
    //----
    public CueService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _CueCollection = database.GetCollection<Cue>(dbSettings.Value.CueCollectionName);
    }
    public async Task<Cue?> Create(Cue cue, CueCard card)
    {
        card.Id = ObjectId.GenerateNewId().ToString();
        await _CueCollection.InsertOneAsync(cue);
        return cue;
    }

    public Task<Cue?> GetById(string id)
    {
        return common.GetById<Cue>(_CueCollection, id);
    }

    public Task<DeleteResult> Delete(string id)
    {
        return common.Delete<Cue>(_CueCollection, id);
    }

    public Task<ReplaceOneResult> Update(string id, Cue cue)
    {
        return common.Update<Cue>(_CueCollection, id,cue);
    }

    public Task<UpdateResult> AddCueTag(string id, Tag tag)
    {
        return common.AddList<Cue>(_CueCollection, id, "Tags", tag.Id);

    }    
    public Task<UpdateResult> RemCueTag(string id, Tag tag)
    {
        return common.RemList<Cue>(_CueCollection, id, "Tags", tag.Id);

    }
    

    public Task<UpdateResult> ChangeCueText(string id, string text)
    {
        return common.ChangeField<Cue, string>(_CueCollection, id, "Markdown", text);
    }

    public Task<UpdateResult> ChangeCuePos(string id, int pos)
    {
        return common.ChangeField<Cue, int>(_CueCollection, id, "Position", pos);

    }
}

class CueCardService:ICueCardService
{
    
    
    private readonly IMongoCollection<CueCard> _CueCardCollection;
    //----
    public CueCardService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _CueCardCollection = database.GetCollection<CueCard>(dbSettings.Value.CueCardCollectionName);
    }
    public async Task<CueCard?> Create(CueCard cueCard, Show show)
    {
        cueCard.Id = ObjectId.GenerateNewId().ToString();
        await _CueCardCollection.InsertOneAsync(cueCard);
        return cueCard;
    }

    public Task<CueCard?> GetById(string id)
    {
        return common.GetById<CueCard>(_CueCardCollection, id);
    }

    public List<string> GetCuesFromCardId(string id)
    {
        return  _CueCardCollection.Find(cc => cc.Id == id).FirstOrDefault().Cues;
        
    }

    public Task<DeleteResult> Delete(string id)
    {
        return common.Delete<CueCard>(_CueCardCollection, id);
    }

    public Task<ReplaceOneResult> Update(string id, CueCard cueCard)
    {
        return common.Update<CueCard>(_CueCardCollection, id,cueCard);

    }
}

class TagService:ITagService
{
    private readonly IMongoCollection<Tag> _TagCollection;
    //----
    public TagService(IOptions<DBSettings> dbSettings, IMongoClient client)
    {
        var database = client.GetDatabase(dbSettings.Value.DBName);
        _TagCollection = database.GetCollection<Tag>(dbSettings.Value.TagCollectionName);
    }
    public async Task<Tag?> Create(Tag tag)
    {
        tag.Id = ObjectId.GenerateNewId().ToString();
        await _TagCollection.InsertOneAsync(tag);
        return tag;
    }

    public Task<Tag?> GetById(string id)
    {
        return common.GetById<Tag>(_TagCollection, id);
    }

    public Task<DeleteResult> Delete(string id)
    {
        return common.Delete<Tag>(_TagCollection, id);
    }

    public Task<ReplaceOneResult> Update(string id, Tag tag)
    {
        return common.Update<Tag>(_TagCollection, id,tag);
    }

    public async Task<List<Tag>> GetPublicTags()
    {
        return await _TagCollection.Find(t => t.IsPublic).ToListAsync();
    }

    public Task<List<Tag>> GetShowTags(string id)
    {
        return GetPublicTags();
        //TODO
    }

    public Task<List<Tag>> GetTags()
    {
        return GetPublicTags();
        //TODO

    }
}