using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Duration
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? CueId { get; set; }
    [BsonIgnore]
    public Cue Cue { get; set; }
    
    
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? SessionId { get; set; }
    [BsonIgnore]
    public Session Session { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)] 
    public bool? UseInAvg { get; set; }
    
     
    
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime start { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime end { get; set; }
    
    
    
}