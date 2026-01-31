using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View.UserValidation;

public partial class SignOutPage : ContentPage
{
    public SignOutPage()
    {
        InitializeComponent();
    }

    private void SignOutButton_OnClicked(object? sender, EventArgs e)
    {
        GameService.currentUser = null;
        Shell.Current.GoToAsync("///StartPage");
    }
    
    private void QuitGameButton_OnClicked(object? sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private void GoBackToMainMenuButton_OnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MainMenuPage));
    }
}