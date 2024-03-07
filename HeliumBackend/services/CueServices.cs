using HeliumBackend.interfaces;
using HeliumBackend.models;
using MongoDB.Driver;
using Tag = HeliumBackend.models.Tag;

namespace HeliumBackend.services;

public class CueService : ICueService
{
    public Task<Cue?> Create(Cue cue, CueCard card)
    {
        throw new NotImplementedException();
    }

    public Task<Cue?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteResult> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ReplaceOneResult> Update(string id, Cue cue)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateResult> ChangeCueTag(string id, Tag tag)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateResult> ChangeCueText(string id, Tag tag)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateResult> ChangeCueColor(string id, Tag tag)
    {
        throw new NotImplementedException();
    }
}

class CueCardService:ICueCardService
{
    public Task<CueCard?> Create(CueCard cueCard, Show show)
    {
        throw new NotImplementedException();
    }

    public Task<CueCard?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cue>> GetCuesFromCardId(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteResult> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ReplaceOneResult> Update(string id, Cue cue)
    {
        throw new NotImplementedException();
    }
}

class TagService:ITagService
{
    public Task<Tag?> Create(Tag tag)
    {
        throw new NotImplementedException();
    }

    public Task<Tag?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteResult> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ReplaceOneResult> Update(string id, Cue cue)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetPublicTags()
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetShowTags()
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetTags()
    {
        throw new NotImplementedException();
    }
}