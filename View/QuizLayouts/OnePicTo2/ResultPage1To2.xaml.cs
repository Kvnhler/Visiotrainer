using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View.QuizLayouts.OnePicTo2;

public partial class ResultPage1To2 : ContentPage
{
    public ResultPage1To2()
    {
        InitializeComponent();
        Resume.Text = "Du hast " + OnePicTwoAnswers.RightAnswers + " von 5 Fragen richtig beantwortet und " + OnePicTwoAnswers.ScoreCount + " Punkte bekommen";;

    }
    
    /// <summary>
    /// resets every variable of the quiz and follows to the menuePage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        GameService.currentUser.score += OnePicTwoAnswers.ScoreCount;
        OnePicTwoAnswers.StaticRoundCounter = 0;
        OnePicTwoAnswers.ChosenAnswerWasCorrect = false;
        OnePicTwoAnswers.ScoreCount = 0;
        OnePicTwoAnswers.RightAnswers = 0;
        DataBaseService.UpdateUser(GameService.currentUser);
        Shell.Current.GoToAsync(nameof(MainMenuPage));
    }
}