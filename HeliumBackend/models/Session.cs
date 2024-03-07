using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Session
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [Required(ErrorMessage = "ShowName is required")]
    public string Sessionname { get; set; } = null!;
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Durations { get; set; } = null!;
    [BsonIgnore]
    public List<Duration> DurationsList { get; set; } = null!;
    [BsonRepresentation(BsonType.ObjectId)]
    public string CueId { get; set; } = null!;
    [BsonIgnore] 
    public Cue Cue { get; set; } = null!;

}