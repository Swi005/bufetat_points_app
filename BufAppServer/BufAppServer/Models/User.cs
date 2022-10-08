using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BufAppServer.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    /**
     * The hashed password of the user
     */
    public string PasswordHash { get; set; } = null!;
    
}