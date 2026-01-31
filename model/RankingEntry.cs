namespace Visiotrainer.model;

/// <summary>
/// this class is used for the creation of the ranking table
/// </summary>
public class RankingEntry
{
    public int Rank { get; set; }  
    public string UserName { get; set; } = "";
    public int Score { get; set; }
}