using BufAppServer.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BufAppServer.Models;

public class Event
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    /**
     * User who does the event
     */
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Actor { get; set; }
    
    /**
     * User who has the event done to them
     */
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Subject { get; set; }

    /**
     * Description of the event
     */
    public string Description { get; set; } = null!;
 
    /**
     * The change of points
     */
    public int PointDelta { get; set; }
    
}