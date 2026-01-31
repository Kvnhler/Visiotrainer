using System.Data;
using MySql.Data.MySqlClient;
using Visiotrainer;
using Visiotrainer.model;

public class DataBaseService
{
   private static readonly string _connectionString =
        "Server=localhost;Database=mydatabase;Uid=root;Pwd=YOUR_PASSWORD_HERE;";

    /// <summary>
    /// loads all user-objects from the DB in GameService.Users
    /// </summary>
    public static void LoadAllUsers()
    {
        GameService.Users.Clear();

        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        const string query = "SELECT username, password, score, falseMadeQuestionsId FROM users";

        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string username = reader.GetString(reader.GetOrdinal("username"));
            string password = reader.GetString(reader.GetOrdinal("password"));
            int score = reader.GetInt32(reader.GetOrdinal("score"));

            int idxFalse = reader.GetOrdinal("falseMadeQuestionsId");
            string csv = reader.IsDBNull(idxFalse) ? "" : reader.GetString(idxFalse);

            List<string> falseIds;
            if (string.IsNullOrWhiteSpace(csv))
            {
                falseIds = new List<string>();
            }
            else
            {
                falseIds = csv
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();
            }

            var user = new User(username, password, score, falseIds);
            GameService.Users.Add(user);
        }
    }

    /// <summary>
    /// Adds a new user to the Database
    /// </summary>
    public static void AddUser(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        string csv = (user.falseMadeQuestionsId == null || user.falseMadeQuestionsId.Count == 0)
            ? ""
            : string.Join(",", user.falseMadeQuestionsId);

        const string query =
            "INSERT INTO users (username, password, score, falseMadeQuestionsId) " +
            "VALUES (@u, @p, @s, @f)";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@u", user.Username);
        cmd.Parameters.AddWithValue("@p", user.Password);
        cmd.Parameters.AddWithValue("@s", user.score);
        cmd.Parameters.AddWithValue("@f", csv);

        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// actualizes the score of the user in the database
    /// </summary>
    public static void UpdateUser(User user)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        string csv = (user.falseMadeQuestionsId == null || user.falseMadeQuestionsId.Count == 0)
            ? ""
            : string.Join(",", user.falseMadeQuestionsId);

        const string query =
            "UPDATE users " +
            "SET password = @p, score = @s, falseMadeQuestionsId = @f " +
            "WHERE username = @u";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@p", user.Password);
        cmd.Parameters.AddWithValue("@s", user.score);
        cmd.Parameters.AddWithValue("@f", csv);
        cmd.Parameters.AddWithValue("@u", user.Username);

        cmd.ExecuteNonQuery();
    }
    
    /// <summary>
    /// adds new Id of the wrong answered question to the database
    /// </summary>
    /// <param name="user"></param>
    /// <param name="questionId"></param>
    public static void AddFalseQuestionId(User user, string questionId)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        // list update (so that the object stays correct)
        if (!user.falseMadeQuestionsId.Contains(questionId))
        {
            user.falseMadeQuestionsId.Add(questionId);
        }
            

        string csv = string.Join(",", user.falseMadeQuestionsId);

        const string query =
            "UPDATE users SET falseMadeQuestionsId=@f WHERE username=@u";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@f", csv);
        cmd.Parameters.AddWithValue("@u", user.Username);

        cmd.ExecuteNonQuery();
    }
    
    public static void RemoveFalseQuestionId(User user, string questionId)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        // remove from list
        user.falseMadeQuestionsId.Remove(questionId);

        string csv = (user.falseMadeQuestionsId.Count == 0)
            ? ""
            : string.Join(",", user.falseMadeQuestionsId);

        const string query =
            "UPDATE users SET falseMadeQuestionsId=@f WHERE username=@u";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@f", csv);
        cmd.Parameters.AddWithValue("@u", user.Username);

        cmd.ExecuteNonQuery();
    }
}
