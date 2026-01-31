using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignInPage));
    }

    private async void RegisterButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));

    }

    private void ExitGameButton_OnClicked(object? sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}