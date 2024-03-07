using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Group
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; }
    [Required(ErrorMessage = "groupname is required")]
    public string GroupName { get; set; } = null!;
    //group users
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Users { get; set; } = null!;
    [BsonIgnore]
    public List<User> UsersList { get; set; } = null!;
    //group owers (admins)
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Owners { get; set; } = null!;
    [BsonIgnore]
    public List<User> OwnersList { get; set; } = null!;
    //group shows (Projects) 
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Shows { get; set; } = null!;
    [BsonIgnore]
    public List<Show> ShowsList { get; set; } = null!;
}