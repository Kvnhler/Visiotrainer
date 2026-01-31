namespace Visiotrainer.model;
/// <summary>
/// this class is for the 5 To 1 kind of quiz
/// </summary>
public class DermoscopySet
{
    public string id{get;}
    public Dermoscopy[] Dermoscopies{get;}

    public DermoscopySet(string id, Dermoscopy[] dermoscopies)
    {
        this.id = id;
        Dermoscopies = dermoscopies;
    }
}