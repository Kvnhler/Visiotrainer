using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.View.UserValidation;

namespace VisioTrainer.ViewModel;

public partial class MainMenuPage : ContentPage
{
    public MainMenuPage()
    {
        InitializeComponent();
        AnimateScore(Score, 0, GameService.currentUser.score);
        currentUser.Text = GameService.currentUser.Username;
    }

    private void PowerButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SignOutPage));
    }
    
    /// <summary>
    /// this method creates the animation of the scorecount
    /// </summary>
    /// <param name="label"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public async Task AnimateScore(Label label, int start, int end)
    {
        const int duration = 1500; // 1 second
        int frameRate = 30; // 30 Frames per second
        int totalFrames = duration / (1000 / frameRate);

        for (int i = 0; i <= totalFrames; i++)
        {
            double progress = (double)i / totalFrames;
            int currentValue = (int)(start + (end - start) * progress);
            label.Text = currentValue.ToString();
            await Task.Delay(1000 / frameRate);
        }
    }
}