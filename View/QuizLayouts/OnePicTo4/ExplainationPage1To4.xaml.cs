using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer.model;

namespace VisioTrainer.View.QuizLayouts;

public partial class ExplainationPage1To4 : ContentPage
{
    public ExplainationPage1To4()
    {
        InitializeComponent();
        if (OnePicFourAnswers.chosenAnswerWasCorrect == true)
        {
            AnswerState.Text = "Richtig";
            }
        else
        {
            AnswerState.Text = "Falsch";
        }
        ExplainImage.Source = OnePicFourAnswers.SavedQuiz[OnePicFourAnswers.StaticRoundCounter].PathDermoscopyAndExpain;
        string explaination = File.ReadAllText(OnePicFourAnswers.SavedQuiz[OnePicFourAnswers.StaticRoundCounter].PathExplaination);
        Explaination.Text = explaination;
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        // next question
        OnePicFourAnswers.StaticRoundCounter++;

        // 1) check if end of the quiz is reached
        if (OnePicFourAnswers.StaticRoundCounter >= OnePicFourAnswers.SavedQuiz.Length)
        {
            // quiz is done navigate to ResultPage
            await Shell.Current.GoToAsync(nameof(ResultPage1To4));

            return;
        }
        // 2) if there is another question navigate back to question Page
        await Shell.Current.GoToAsync(nameof(OnePicFourAnswers));
    }
}