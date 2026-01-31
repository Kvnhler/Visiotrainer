using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// this Method will be executed if the "Anmelden" - Button will be Clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void LoginButton_OnClicked(object? sender, EventArgs e)
    {
        if (GameService.LoginUser(UsernameEntry.Text, UserPasswordEntry.Text))
            //In this Line things happen: 1.check successful login, 2.set current user
        {
            DisplayAlert("Anmeldung", "Du bist eingeloggt!", "OK");
            Shell.Current.GoToAsync(nameof(MainMenuPage));
        }
        else
        {
            ErrorLogin.IsVisible = true;
        }
    }

    /// <summary>
    /// by changing the text the red Error text will be removed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UserPasswordEntry_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        ErrorLogin.IsVisible = false;
    }

    /// <summary>
    /// by changing the text the red Error text will be removed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UsernameEntry_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        ErrorLogin.IsVisible = false;
    }
}