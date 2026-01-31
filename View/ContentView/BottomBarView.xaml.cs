using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View;
/// <summary>
/// this class creates the BottomBarView with the different icons and buttons
/// </summary>
public partial class BottomBarView : ContentView
{
    public BottomBarView()
    {
        InitializeComponent();
    }

    private void HomeButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MainMenuPage));
    }

    private void QuizButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(QuizClickedPage));
    }

    private void RankingButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RankingClickedPage));

    }

    private void ViewMistakesButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FalseMadeQuestions));
    }
}