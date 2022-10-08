using BufAppServer.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BufAppServer.Models;

public class Bruker
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /**
     * Foreign Key to a user
     */
    [BsonRepresentation(BsonType.ObjectId)]
    public string? User { get; set; }
    
    /**
     * Unique identifier
     */
    public string Identifier { get; set; } = null!;

    /**
     * Number of points the Bruker has.
     *
     * NOTE: Perhaps change this from being a db field to something that is calculated when
     * asked for since that needs to happen anyways.
     */
    public int Points { get; set; }

}