using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;

namespace VisioTrainer.View.QuizLayouts;

public partial class OnePicFourAnswers : ContentPage
{
    static int staticRoundCounter;
    private static Dermoscopy[] savedQuiz;
    private static string[] allDiagnosis;
    public static bool chosenAnswerWasCorrect;
    private static int scoreCount;


    public static int rightAnswers;

    #region Getter and Setter

    public static int ScoreCount
    {
        get => scoreCount;
        set => scoreCount = value;
    }

    public static int StaticRoundCounter
    {
        get => staticRoundCounter;
        set => staticRoundCounter = value;
    }

    public static Dermoscopy[] SavedQuiz
    {
        get => savedQuiz;
        set => savedQuiz = value ?? throw new ArgumentNullException(nameof(value));
    }

    #endregion

    public OnePicFourAnswers()
    {
        InitializeComponent();

        if (staticRoundCounter == 0)
        {
            savedQuiz = QuizService.make1To4Quiz();
        }

        mixAllDiagnosis();

        Image.Source = savedQuiz[staticRoundCounter].PathDermoscopy;

        OptionsLayout.Children.Clear();

        //dynamically creation of the answeroption buttons
        foreach (var diagnosis in allDiagnosis)
        {
            var button = new Button { Text = diagnosis };

            button.Clicked += Option_OnClicked;

            OptionsLayout.Children.Add(button);
        }
    }


    /// <summary>
    /// In this method all given Diagnosises will be mixed and saved in an array
    /// </summary>
    private static void mixAllDiagnosis()
    {
        if (savedQuiz == null || savedQuiz.Length == 0)
            throw new InvalidOperationException(
                "savedQuiz ist null oder leer. QuizService.make1To4Quiz() liefert nichts zurück.");

        if (staticRoundCounter < 0 || staticRoundCounter >= savedQuiz.Length)
            throw new IndexOutOfRangeException(
                $"staticRoundCounter={staticRoundCounter}, aber savedQuiz.Length={savedQuiz.Length}");

        var currentQuestionPicture = savedQuiz[staticRoundCounter];
        if (currentQuestionPicture == null)
            throw new InvalidOperationException(
                "currentQuestionPicture ist null – Eintrag im Array ist nicht gesetzt.");

        var allStrings = new[] { currentQuestionPicture.Realdiagnosis }
            .Concat(currentQuestionPicture.Differentialdiagnosis ?? Array.Empty<string>());

        var rand = new Random();
        allDiagnosis = allStrings
            .OrderBy(x => rand.Next())
            .ToArray();
    }
    
    /// <summary>
    /// proves whether the option is correct or not
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Option_OnClicked(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            var text = button.Text;
            proveIfClickedOptionIsCorrect(text);
        }
    }

    /// <summary>
    /// this method compares the given answer with the realdiagnosis and sets the important variables
    /// </summary>
    /// <param name="option"></param>
    private async void proveIfClickedOptionIsCorrect(string option)
    {
        if (savedQuiz[staticRoundCounter].Realdiagnosis.Equals(option))
        {
            chosenAnswerWasCorrect = true;
            scoreCount += 10;
            rightAnswers++;
            await Shell.Current.GoToAsync(nameof(ExplainationPage1To4));
        }
        else
        {
            chosenAnswerWasCorrect = false;
            if (!GameService.currentUser.falseMadeQuestionsId.Contains(SavedQuiz[StaticRoundCounter].Id))
            {
                GameService.currentUser.falseMadeQuestionsId.Add(SavedQuiz[StaticRoundCounter].Id);
            }

            DataBaseService.AddFalseQuestionId(GameService.currentUser, SavedQuiz[StaticRoundCounter].Id);
            await Shell.Current.GoToAsync(nameof(ExplainationPage1To4));
        }
    }
}