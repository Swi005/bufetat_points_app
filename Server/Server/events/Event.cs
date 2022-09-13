using Server.users;
namespace Server.events;
public enum Change
{
    Positive,
    Negative
}

public class Event
{
    private User User { get; }
    private Admin Admin{ get; }
    private Change Type{ get; }
    private int PointDelta{ get; }
    private string Description{ get; }

    public Event(Change type, Admin admin, User user, int pointDelta, string description)
    {
        this.Type = type;
        this.Admin = admin;
        this.User = user;
        this.PointDelta = pointDelta;
        this.Description = description;
    }
}