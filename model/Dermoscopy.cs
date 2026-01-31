namespace Visiotrainer.model;
/// <summary>
/// this class is the blueprint of the Dermoscopy object
/// </summary>
public class Dermoscopy
{
    public string Id { get;}
    public string Realdiagnosis { get;}
    public string[] Differentialdiagnosis { get;}
    public string PathDermoscopy { get;}
    public string PathDermoscopyAndExpain { get;}
    public string PathExplaination { get;}
    public bool Benigne { get;}

    /// <summary>
    /// this is the construktor for PictureObjects of the 1To4 quiz
    /// </summary>
    /// <param name="id"></param>
    /// <param name="realdiagnosis"></param>
    /// <param name="differentialdiagnosis"></param>
    /// <param name="pathDermoscopy"></param>
    /// <param name="pathDermoscopyAndExpain"></param>
    /// <param name="pathExplaination"></param>
    public Dermoscopy(string id, string realdiagnosis, string[] differentialdiagnosis, string pathDermoscopy, string pathDermoscopyAndExpain, string pathExplaination)
    {
        Id = id;
        Realdiagnosis = realdiagnosis;
        Differentialdiagnosis = differentialdiagnosis;
        PathDermoscopy = pathDermoscopy;
        PathDermoscopyAndExpain = pathDermoscopyAndExpain;
        PathExplaination = pathExplaination;
    }

    /// <summary>
    /// this constructor is for the 1To2 quizPictures
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pathDermoscopy"></param>
    /// <param name="benigne"></param>
    public Dermoscopy(string id, string pathDermoscopy, bool benigne)
    {
        Id = id;
        PathDermoscopy = pathDermoscopy;
        Benigne = benigne;
    }

    /// <summary>
    /// this constructor is for the 5To1 quizPictures
    /// </summary>
    public Dermoscopy(string pathDermoscopy, bool benigne)
    {
        PathDermoscopy = pathDermoscopy;
        Benigne = benigne;
    }
}