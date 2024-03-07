using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Duration
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime start { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime end { get; set; }
    
}