using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Cue
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [Required(ErrorMessage = "quename is required")]
    public string QueName { get; set; } = null!;
    [Required(ErrorMessage = "text is required")]
    public string Markdown { get; set; } = null!;
    public List<string> FunctionTag { get; set; } = null!;
    //Cue Tags
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Tags { get; set; } = null!;
    [BsonIgnore]
    public List<User> TagsList { get; set; } = null!;
    
    //Cue Recorded Durations
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Durations { get; set; } = null!;
    [BsonIgnore]
    public List<Duration> DurationsList { get; set; } = null!;
    
    
    
    [Required(ErrorMessage = "position is required")]
    public int Position;
}