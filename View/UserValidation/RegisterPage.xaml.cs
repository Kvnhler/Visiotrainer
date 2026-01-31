using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void RegisterButton_OnClicked(object? sender, EventArgs e)
    {
        User newMadeUser;
        
        //here will be checked if the User already exists in the GameService User List, if the user is given....
        foreach (User user in GameService.Users)
        {
            if (user.Username.Equals(UsernameEntry.Text))
            {
                ErrorRegister.IsVisible = true;
            }
        }

        //if the user is not given in the users list...
        if (ErrorRegister.IsVisible == false)
        {
            newMadeUser = new User(UsernameEntry.Text, PasswordEntry.Text, 0, new List<string>());
            GameService.RegisterNewUser(newMadeUser);
            DataBaseService.AddUser(newMadeUser);
            DisplayAlert("Registration erfolgreich", "Registrieren erfolgreich!\nBitte melde dich erneut an!", "OK");
            Shell.Current.GoToAsync("///StartPage");
        }
    }

    /// <summary>
    /// removes the error-Message by changing the text
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UsernameEntry_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        ErrorRegister.IsVisible = false;
    }
}