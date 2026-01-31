using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using VisioTrainer.ViewModel;

namespace VisioTrainer.View.QuizLayouts.FivePicsTo1;

public partial class ResultPage5To1 : ContentPage
{
    public ResultPage5To1()
    {
        InitializeComponent();
        //this shows the following text based on the given answer before
        if (FivePicsOneAnswer.answerIsCorrect)
        {
            Resume.Text = "Richtig, Du hast die Maligne Läsion identifiziert. Du hast " + FivePicsOneAnswer.ScoreCounter + " Punkte bekommen";
        }
        else
        {
            Resume.Text = "Falsch, Das war leider nicht die richtige Läsion";
        }
    }

    /// <summary>
    /// this method ends a quiz, updates the UserdScore and also in the DB + it updates the boolean ActualLookAtMistakes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_OnClicked(object sender, EventArgs e)
    {
        GameService.currentUser.score += FivePicsOneAnswer.ScoreCounter;
        DataBaseService.UpdateUser(GameService.currentUser);
        FalseMadeQuestions.ActualLookAtMistakes = false;
        Shell.Current.GoToAsync(nameof(MainMenuPage));
    }
}