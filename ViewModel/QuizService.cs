using Visiotrainer.model;

namespace Visiotrainer;

//The QuizServiceClass is there to manage the loading of the Quizpictures and the creation of a quiz
public class QuizService
{
    static List<Dermoscopy> OneToFourPics = new List<Dermoscopy>();

    static List<Dermoscopy> OneToTwoPics = new List<Dermoscopy>();

    static List<DermoscopySet> FiveToOnePics = new List<DermoscopySet>();

    static Random rnd = new Random();


    #region creating Pathes

    private static string projectDir = AppDomain.CurrentDomain.BaseDirectory;

    #region Pathes for 1to4

    private static string imagePath1a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0001.png");
    private static string imagePath2a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0002.png");
    private static string imagePath3a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0003.png");
    private static string imagePath4a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0004.png");
    private static string imagePath5a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0005.png");
    private static string imagePath6a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0006.png");
    private static string imagePath7a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0007.png");
    private static string imagePath8a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0008.png");
    private static string imagePath9a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0009.png");
    private static string imagePath10a = Path.Combine(projectDir, @"Quizbilder\1to4\Pictures\0010.png");
    
    private static string imagePath1aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0001.txt");
    private static string imagePath2aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0002.txt");
    private static string imagePath3aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0003.txt");
    private static string imagePath4aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0004.txt");
    private static string imagePath5aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0005.txt");
    private static string imagePath6aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0006.txt");
    private static string imagePath7aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0007.txt");
    private static string imagePath8aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0008.txt");
    private static string imagePath9aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0009.txt");
    private static string imagePath10aE = Path.Combine(projectDir, @"Quizbilder\1to4\Explainations\0010.txt");
    
    private static string imagePath1aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0001.png");
    private static string imagePath2aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0002.png");
    private static string imagePath3aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0003.png");
    private static string imagePath4aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0004.png");
    private static string imagePath5aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0005.png");
    private static string imagePath6aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0006.png");
    private static string imagePath7aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0007.png");
    private static string imagePath8aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0008.png");
    private static string imagePath9aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0009.png");
    private static string imagePath10aED = Path.Combine(projectDir, @"Quizbilder\1to4\ExplainPictures\0010.png");

    #endregion
    
    #region Pathes for 1to2

    private static string imagePath1b = Path.Combine(projectDir, @"Quizbilder\1to2\0001.png");
    private static string imagePath2b = Path.Combine(projectDir, @"Quizbilder\1to2\0002.png");
    private static string imagePath3b = Path.Combine(projectDir, @"Quizbilder\1to2\0003.png");
    private static string imagePath4b = Path.Combine(projectDir, @"Quizbilder\1to2\0004.png");
    private static string imagePath5b = Path.Combine(projectDir, @"Quizbilder\1to2\0005.png");
    private static string imagePath6b = Path.Combine(projectDir, @"Quizbilder\1to2\0006.png");
    private static string imagePath7b = Path.Combine(projectDir, @"Quizbilder\1to2\0007.png");
    private static string imagePath8b = Path.Combine(projectDir, @"Quizbilder\1to2\0008.png");
    private static string imagePath9b = Path.Combine(projectDir, @"Quizbilder\1to2\0009.png");
    private static string imagePath10b = Path.Combine(projectDir, @"Quizbilder\1to2\0010.png");
    
    #endregion
    
    #region Pathes for 5to1

    private static string imagePath1c1 = Path.Combine(projectDir, @"Quizbilder\5to1\0001\0001.png");
    private static string imagePath1c2 = Path.Combine(projectDir, @"Quizbilder\5to1\0001\0002.png");
    private static string imagePath1c3 = Path.Combine(projectDir, @"Quizbilder\5to1\0001\0003.png");
    private static string imagePath1c4 = Path.Combine(projectDir, @"Quizbilder\5to1\0001\0004.png");
    private static string imagePath1c5 = Path.Combine(projectDir, @"Quizbilder\5to1\0001\0005.png");

    #endregion
    

    #endregion


    #region Getter and Setter

    public static List<Dermoscopy> OneToFourPics1
    {
        get => OneToFourPics;
        set => OneToFourPics = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static List<Dermoscopy> OneToTwoPics1
    {
        get => OneToTwoPics;
        set => OneToTwoPics = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static List<DermoscopySet> FiveToOnePics1
    {
        get => FiveToOnePics;
        set => FiveToOnePics = value ?? throw new ArgumentNullException(nameof(value));
    }

    #endregion

    public static void InitializeTestQuizPictures()
    {
        #region 1 To 4 Pictures

        OneToFourPics.Add(new Dermoscopy("1a", "Melanom",
            new string[] { "Pigmentiertes Basaliom", "Seborrhoische Keratose", "Spitz-Naevus" },
            imagePath1a,
            imagePath1aED,
            imagePath1aE));

        OneToFourPics.Add(new Dermoscopy("2a", "Melanom in situ",
            new string[] { "Pigmentiertes Basaliom", "Seborrhoische Keratose", "intradermaler Naevus" },
            imagePath2a,
            imagePath2aED,
            imagePath2aE));

        OneToFourPics.Add(new Dermoscopy("3a", "Melanom in situ",
            new string[] { "Pigmentiertes Basaliom", "Seborrhoische Keratose", "intradermaler Naevus" },
            imagePath3a,
            imagePath3aED,
            imagePath3aE));

        OneToFourPics.Add(new Dermoscopy("4a", "Lentigo maligna",
            new string[] { "Lentigo solaris", "flache Seborrhoische Keratose", "Naevus" },
            imagePath4a,
            imagePath4aED,
            imagePath4aE));

        OneToFourPics.Add(new Dermoscopy("5a", "Melanom",
            new string[] { "Pigmentiertes Basaliom", "Seborrhoische Keratose", "Spinaliom" },
            imagePath5a,
            imagePath5aED,
            imagePath5aE));

        OneToFourPics.Add(new Dermoscopy("6a", "Palmarer melanozytärer Naevus",
            new string[] { "Melanom", "Hämatom", "Spitz-Naevus" },
            imagePath6a,
            imagePath6aED,
            imagePath6aE));

        OneToFourPics.Add(new Dermoscopy("7a", "melanozytärer benigner Naevus",
            new string[] { "Melanom in Situ", "Seborrhoische Keratose", "Naevus Congenitalis" },
            imagePath7a,
            imagePath7aED,
            imagePath7aE));

        OneToFourPics.Add(new Dermoscopy("8a", "pigmentierter Morbus Bowen",
            new string[] { "Spinaliom", "Basaliom", "melanozytärer Naevus" },
            imagePath8a,
            imagePath8aED,
            imagePath8aE));

        OneToFourPics.Add(new Dermoscopy("9a", "Lentigo Simplex",
            new string[] { "Pigmentiertes Basaliom", "Seborrhoische Keratose", "Spitz-Naevus" },
            imagePath9a,
            imagePath9aED,
            imagePath9aE));

        OneToFourPics.Add(new Dermoscopy("10a", "pigmentiertes Basaliom",
            new string[] { "Ekzem", "pigmentiertes Spinaliom", "Melanom" },
            imagePath10a,
            imagePath10aED,
            imagePath10aE));

        #endregion

        //All false ones are maligne

        #region 1 To 2 Pictures

        OneToTwoPics.Add(new Dermoscopy("1b", imagePath1b, true));
        OneToTwoPics.Add(new Dermoscopy("2b",
            imagePath2b, false));
        OneToTwoPics.Add(new Dermoscopy("3b",
            imagePath3b, false));
        OneToTwoPics.Add(new Dermoscopy("4b",
            imagePath4b, false));
        OneToTwoPics.Add(new Dermoscopy("5b",
            imagePath5b, false));
        OneToTwoPics.Add(new Dermoscopy("6b",
            imagePath6b, true));
        OneToTwoPics.Add(new Dermoscopy("7b",
            imagePath7b, false));
        OneToTwoPics.Add(new Dermoscopy("8b",
            imagePath8b, false));
        OneToTwoPics.Add(new Dermoscopy("9b",
            imagePath9b, true));
        OneToTwoPics.Add(new Dermoscopy("10b",
            imagePath10b, false));

        #endregion

        #region 5 To 1 Pictures

        FiveToOnePics.Add(new DermoscopySet("1c", new Dermoscopy[]
        {
            new Dermoscopy(imagePath1c1,
                true),
            new Dermoscopy(imagePath1c2,
                false),
            new Dermoscopy(imagePath1c3,
                false),
            new Dermoscopy(imagePath1c4,
                false),
            new Dermoscopy(imagePath1c5,
                false)
        }));

        #endregion
    }

    public static Dermoscopy[] make1To4Quiz()
    {
        //Here there will be taken 5 random Objekts from the List and put into an Array
        Dermoscopy[] madeQuiz = OneToFourPics.OrderBy(x => rnd.Next()).Take(5).ToArray();
        return madeQuiz;
    }

    public static Dermoscopy[] make1To2Quiz()
    {
        //Here there will be taken 5 random objects from the list and put into an Array
        Dermoscopy[] madeQuiz = OneToTwoPics.OrderBy(x => rnd.Next()).Take(5).ToArray();
        return madeQuiz;
    }

    public static DermoscopySet get1RandomQuizFromList()
    {
        if (FiveToOnePics == null || FiveToOnePics.Count == 0)
            throw new ArgumentException("Liste ist leer.");

        int index = rnd.Next(FiveToOnePics.Count);
        return FiveToOnePics[index];
    }
}