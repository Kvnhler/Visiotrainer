using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioTrainer.View.ControlOptions.FalseMadeQuestionControl;

public partial class GeneralExplainationPage : ContentPage
{
    public GeneralExplainationPage()
    {
        InitializeComponent();
        AnswerState.Text = "Falsch";

        // null testing to avoid NullPointerException
        if (FalseMadeQuestions.CurrentUsedDermoscopy == null)
        {
            Explaination.Text = "Fehler: Es wurde keine Dermoskopie zur Anzeige gefunden.";
            return;
        }
        
        if (FalseMadeQuestions.CurrentUsedDermoscopy.Id.EndsWith("a"))
        {
            ExplainImage.Source = FalseMadeQuestions.CurrentUsedDermoscopy.PathDermoscopyAndExpain;
            Explaination.Text = File.ReadAllText(FalseMadeQuestions.CurrentUsedDermoscopy.PathExplaination);
        }
        else if (FalseMadeQuestions.CurrentUsedDermoscopy.Id.EndsWith("b"))
        {
            ExplainImage.Source = FalseMadeQuestions.CurrentUsedDermoscopy.PathDermoscopy;
            Explaination.Text = "Diese Läsion ist die Maligne";
        }
        else
        {
            ExplainImage.Source = FalseMadeQuestions.CurrentUsedDermoscopy.PathDermoscopy;
            Explaination.Text = "Diese Läsion ist die Maligne";
        }
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FalseMadeQuestions));
    }
}