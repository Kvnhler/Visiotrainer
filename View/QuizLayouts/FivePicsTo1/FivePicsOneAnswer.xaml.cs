using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.View.ControlOptions.FalseMadeQuestionControl;
using VisioTrainer.View.QuizLayouts.FivePicsTo1;

namespace VisioTrainer.View.QuizLayouts;

public partial class FivePicsOneAnswer : ContentPage
{
    public static DermoscopySet currentQuiz { get; set; }
    private static string[] dermoscopyPathes;
    private static string ClickedImagePath;
    public static bool answerIsCorrect;
    public static int ScoreCounter;
    public static bool scoreCountAllowed;


    #region Getter and Setter

    public string[] DermoscopyPathes
    {
        get => dermoscopyPathes;
        set => dermoscopyPathes = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ClickedImagePath1
    {
        get => ClickedImagePath;
        set => ClickedImagePath = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool AnswerIsCorrect
    {
        get => answerIsCorrect;
        set => answerIsCorrect = value;
    }

    public int ScoreCounter1
    {
        get => ScoreCounter;
        set => ScoreCounter = value;
    }

    #endregion


    public FivePicsOneAnswer()
    {
        InitializeComponent();
        
        ResetQuiz();

        if (FalseMadeQuestions.ActualLookAtMistakes)
        {
            currentQuiz = FalseMadeQuestions.CurrentUsedDermoscopySet;
            scoreCountAllowed = false;
        }
        else
        {
            currentQuiz = QuizService.get1RandomQuizFromList();
            scoreCountAllowed = true;
        }

        // getting 5 pathes
        dermoscopyPathes = currentQuiz.Dermoscopies
            .Select(d => d.PathDermoscopy)
            .Take(5)
            .ToArray();

        // making sure that there are 5 pathes given
        if (dermoscopyPathes.Length < 5)
            throw new InvalidOperationException("Es werden mindestens 5 Dermoscopy-Bilder für dieses Layout benötigt.");

        LoadImagesIntoGrid();

        var dermoscopies = currentQuiz.Dermoscopies.Take(5).ToList();

        // Set BindingContext for every Picture
        Img0.BindingContext = dermoscopies[0];
        Img1.BindingContext = dermoscopies[1];
        Img2.BindingContext = dermoscopies[2];
        Img3.BindingContext = dermoscopies[3];
        Img4.BindingContext = dermoscopies[4];

        // Top Handler for Overlay
        var overlayTap = new TapGestureRecognizer();
        overlayTap.Tapped += OnOverlayTapped;
        Overlay.GestureRecognizers.Add(overlayTap);
    }

    /// <summary>
    /// Loads images into the gridlayout
    /// </summary>
    private void LoadImagesIntoGrid()
    {
        Img0.Source = ImageSource.FromFile(dermoscopyPathes[0]);
        Img1.Source = ImageSource.FromFile(dermoscopyPathes[1]);
        Img2.Source = ImageSource.FromFile(dermoscopyPathes[2]);
        Img3.Source = ImageSource.FromFile(dermoscopyPathes[3]);
        Img4.Source = ImageSource.FromFile(dermoscopyPathes[4]);
    }

    /// <summary>
    /// The image will be shown in the center of the screen if the Image is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnImageTapped(object sender, TappedEventArgs e)
    {
        if (sender is not Image img || img.Source is null)
            return;

        FullscreenImage.Source = img.Source;
        Overlay.IsVisible = true;
    }

    /// <summary>
    /// The Overlay will be closed by clicking on it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnOverlayTapped(object sender, EventArgs e)
    {
        Overlay.IsVisible = false;
    }

    /// <summary>
    /// This method gives the selected index of the button 
    /// </summary>
    /// <returns></returns>
    private int GetSelectedIndex()
    {
        if (Rb0.IsChecked) return 0;
        if (Rb1.IsChecked) return 1;
        if (Rb2.IsChecked) return 2;
        if (Rb3.IsChecked) return 3;
        if (Rb4.IsChecked) return 4;
        return -1; //if nothing is chosen
    }

    /// <summary>
    /// if the submitButton is clicked, the result will be proved and the player led to the next Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Finde heraus, welcher RadioButton ausgewählt wurde
        int selectedIndex = GetSelectedIndex();
        if (selectedIndex == -1)
        {
            await DisplayAlert("Hinweis", "Bitte wähle eine Läsion aus.", "OK");
            return;
        }

        // get the chosen picture by the selected index
        Image selectedImage = selectedIndex switch
        {
            0 => Img0,
            1 => Img1,
            2 => Img2,
            3 => Img3,
            4 => Img4,
            _ => null
        };

        if (selectedImage?.BindingContext is Dermoscopy selectedDermoscopy)
        {
            // prove if the given picture is malignant
            if (selectedDermoscopy.Benigne)
            {
                answerIsCorrect = true;
                if (scoreCountAllowed)
                {
                    ScoreCounter += 60;
                }
                Shell.Current.GoToAsync(nameof(ExplainationFivePicsOneAnswer));
            }
            else
            {
                answerIsCorrect = false;
                //this method-call adds the ID of the false answered questions, if it's not already included
                if (!GameService.currentUser.falseMadeQuestionsId.Contains(currentQuiz.id.ToString()))
                {
                    GameService.currentUser.falseMadeQuestionsId.Add(currentQuiz.id.ToString());
                }
                DataBaseService.AddFalseQuestionId(GameService.currentUser, currentQuiz.id.ToString());
                Shell.Current.GoToAsync(nameof(ExplainationFivePicsOneAnswer));
            }
        }
    }

    /// <summary>
    /// resets all Variables by the start of a new quiz
    /// </summary>
    private static void ResetQuiz()
    {
        currentQuiz = null;
        answerIsCorrect = false;
        ScoreCounter = 0;
        ClickedImagePath = null;
        dermoscopyPathes = null;
    }
}