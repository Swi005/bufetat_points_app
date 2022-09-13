namespace Server.users;

public class User : IUser
{
    public User(int userId)
    {
        this.GetUserId = userId;
    }

    public int GetUserId { get; }

    public bool IsAdmin()
    {
        return false;
    }
}