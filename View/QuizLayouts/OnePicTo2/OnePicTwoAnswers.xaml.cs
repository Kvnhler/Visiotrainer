using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.View.QuizLayouts.OnePicTo2;

namespace VisioTrainer.View.QuizLayouts;

public partial class OnePicTwoAnswers : ContentPage
{
    private static int staticRoundCounter;
    private static Dermoscopy[] savedQuiz;
    private static bool chosenAnswerWasCorrect;
    private static int scoreCount;
    private static int rightAnswers;

    #region Getter and Setter

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

    public static bool ChosenAnswerWasCorrect
    {
        get => chosenAnswerWasCorrect;
        set => chosenAnswerWasCorrect = value;
    }

    public static int ScoreCount
    {
        get => scoreCount;
        set => scoreCount = value;
    }

    public static int RightAnswers
    {
        get => rightAnswers;
        set => rightAnswers = value;
    }

    #endregion

    public OnePicTwoAnswers()
    {
        InitializeComponent();
        
        //if the quiz begins (staticCounter == 0) create one quiz
        if (staticRoundCounter == 0)
        {
            savedQuiz = QuizService.make1To2Quiz();
        }
        
        //fills the Image place with the actual quiz image
        Image.Source = savedQuiz[staticRoundCounter].PathDermoscopy;
    }

    private void BenigneButton_OnClicked(object? sender, EventArgs e)
    {
        checkIfBenigne(true);
        Shell.Current.GoToAsync(nameof(TellIfRightOrWrong));
    }

    private void MaligneButton_OnClicked(object? sender, EventArgs e)
    {
        checkIfBenigne(false);
        Shell.Current.GoToAsync(nameof(TellIfRightOrWrong));
    }

    private static void checkIfBenigne(bool chosenBool)
    {
        if (savedQuiz[staticRoundCounter].Benigne == chosenBool)
        {
            chosenAnswerWasCorrect = true;
            rightAnswers++;
            scoreCount += 5;
        }
        else
        {
            chosenAnswerWasCorrect = false;
            //saves QuestionID in the DataBase
            DataBaseService.AddFalseQuestionId(GameService.currentUser, SavedQuiz[StaticRoundCounter].Id.ToString());
        }
    }
}