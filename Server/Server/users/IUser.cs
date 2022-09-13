namespace Server.users;
/**
 * Interface for representing a client
 * @author: Sander Wiig
 */
public interface IUser
{
    public int GetUserId { get;}
    public bool IsAdmin();
}