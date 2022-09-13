using Server.events;
using Server.users;

namespace Server;

public interface DBInterface
{
     //------------------------------------
    //User APIs
    //------------------------------------
    /**
     * Returns either a client from the DB with the UUID id
     */
    public IUser GetClient(Guid id);
    /**
     * Fetches user with specific user_id 
     */
    public IUser GetClient(int userId);
    /**
     * Returns all clients in the database
     */
    public List<IUser> GetAllClients();
    /**
     * Returns all admins
     */
    public List<Admin> GetAllAdmins();
    /**
     *  Returns all Users in the system 
     */
    public List<User> GetAllUsers();
    /**
     * Check if pswrd matches
     */
    public bool CheckPassword(string attempt, int userId);

    /**
     * Add new user
     */
    public bool AddNewUser(User user, Admin admin);

    /**
     * Add new Admin
     */
    public Admin AddNewAdmin(User user, Admin admin);
    //------------------------------------
    //Points management
    //------------------------------------
    /**
     * Returns the points of a user
     */
    public int GetPoints(User user);
    /**
     * Sets the points of a user
     */
    protected bool SetPoints(User user, Admin admin);


    //------------------------------------
    //Event APIs
    //------------------------------------
    /**
     * Adds event.
     */
    public bool AddPoints(Event @event);
    /**
     * Gets a specific event
     */
    public Event GetEvent(int id);
    /**
     * Returns all events
     */
    public List<Event> GetAllEvents();
    /**
     * returns all events for a specific user
     */
    public List<Event> GetAllUserEvents(User user);
}