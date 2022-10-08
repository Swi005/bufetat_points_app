using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BufAppServer.Models;

public class Admin
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string? User { get; set; }
    
    public string Name { get; set; } = null!;
}