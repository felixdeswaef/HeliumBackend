using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [Required(ErrorMessage = "username is required")] 
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "email is required")] 
    public string Email { get; set; } = null!;
    
    
}