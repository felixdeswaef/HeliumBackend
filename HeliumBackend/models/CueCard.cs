using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class CueCard
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [Required(ErrorMessage = "cardname is required")]
    public string CardName { get; set; } = null!;
    //card cue's
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Cues { get; set; } = null!;
    [BsonIgnore]
    public List<Cue> CuesList { get; set; } = null!;
    [Required(ErrorMessage = "position is required")]
    public int position;
}