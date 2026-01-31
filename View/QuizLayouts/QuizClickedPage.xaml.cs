using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioTrainer.View.QuizLayouts;

namespace VisioTrainer.View;

public partial class QuizClickedPage : ContentPage
{
    public QuizClickedPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Startbutton for 1 picture 4 diagnosis
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnePic4DiagButton_OnClicked(object? sender, EventArgs e)
    {
        OnePicFourAnswers.StaticRoundCounter = 0;
        OnePicFourAnswers.ScoreCount = 0;
        OnePicFourAnswers.rightAnswers = 0;
        Shell.Current.GoToAsync(nameof(OnePicFourAnswers));
    }

    /// <summary>
    /// Startbutton for 1 picture benigne or maligne
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BenigneVsMaligneButton_OnClicked(object? sender, EventArgs e)
    {
        OnePicTwoAnswers.StaticRoundCounter = 0;
        Shell.Current.GoToAsync(nameof(OnePicTwoAnswers));
    }

    /// <summary>
    /// Startbutton for 5 pictures and one maligne
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FivePicsOneMaligneButton_OnClicked(object? sender, EventArgs e)
    {
        FivePicsOneAnswer.ScoreCounter = 0;
        FivePicsOneAnswer.scoreCountAllowed = true;
        FalseMadeQuestions.ActualLookAtMistakes = false;
        Shell.Current.GoToAsync(nameof(FivePicsOneAnswer));
    }
}