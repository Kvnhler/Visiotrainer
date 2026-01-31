using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View.QuizLayouts;

public partial class ResultPage1To4 : ContentPage
{
    public ResultPage1To4()
    {
        InitializeComponent();
        Resume.Text = "Du hast " + OnePicFourAnswers.rightAnswers + " von 5 Fragen richtig beantwortet und " + OnePicFourAnswers.ScoreCount + " Punkte bekommen";;
    }

    /// <summary>
    /// after the quiz the user will be adjusted (score,score in the DB)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        GameService.currentUser.score += OnePicFourAnswers.ScoreCount;
        DataBaseService.UpdateUser(GameService.currentUser);
        Shell.Current.GoToAsync(nameof(MainMenuPage));
    }
}