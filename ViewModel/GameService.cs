using Visiotrainer.model;

namespace Visiotrainer;

public class GameService
{
    public static User currentUser { get; set; }
    
    #region UserList
    static List<User> users = new List<User>();
    
    public static List<User> Users
    {
        get { return users; }
        set { users = value; }
    }
    #endregion

    /// <summary>
    /// if the Player wants to create a new User
    /// </summary>
    public static void RegisterNewUser(User user)
    {
        users.Add(user);
    }

    /// <summary>
    /// makes the UserLogin
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>if User is found and logged in or not</returns>
    public static bool LoginUser(string username, string password)
    {
        foreach (User user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                currentUser = user;
                return true;
            }
        }
        return false;
    }
}