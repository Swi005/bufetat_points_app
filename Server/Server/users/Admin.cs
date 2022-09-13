namespace Server.users;

public class Admin : IUser
{
    
    public Admin(int userId)
    {
        this.GetUserId = userId;
    }

    public int GetUserId { get; }

    public bool IsAdmin()
    {
        return true;
    }
}