using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeliumBackend.models;

public class Tag
{
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)] 
    public string? Id { get; set; } 
    [Required(ErrorMessage = "TagCode is required")] 
    public string TagCode { get; set; } = null!;
    [Required(ErrorMessage = "TagLong is required")] 
    public string TagLong { get; set; } = null!;
    
    public string? TagToolTip { get; set; } = null!;

    [Required(ErrorMessage = "isPublic is required")]
    public bool IsPublic { get; set; } = false;
}