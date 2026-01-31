namespace Visiotrainer.model;
/// <summary>
/// this class is the blueprint of the user object
/// </summary>
public class User
{
    public string Username{get;}
    public string Password{get;}
    public int score{get; set;}
    public List<string> falseMadeQuestionsId{get;}

    public User(string username, string password, int score, List<string> falseMadeQuestionsId)
    {
        Username = username;
        Password = password;
        this.score = score;
        this.falseMadeQuestionsId = falseMadeQuestionsId;
    }
}