using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Show
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [Required(ErrorMessage = "ShowName is required")]
    public string ShowName { get; set; } = null!;
    //Show owers (admins)
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Owners { get; set; } = null!;
    [BsonIgnore]
    public List<User> OwnersList { get; set; } = null!;
    //Show cards 
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Cards { get; set; } = null!;
    [BsonIgnore]
    public List<CueCard> CardsList { get; set; } = null!;
    
    //Show Sessions
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Sessions { get; set; } = null!;
    [BsonIgnore]
    public List<Session> SessionsList { get; set; } = null!;
    
}