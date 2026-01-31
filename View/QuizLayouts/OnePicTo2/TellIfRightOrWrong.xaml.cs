using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;

namespace VisioTrainer.View.QuizLayouts.OnePicTo2;

public partial class TellIfRightOrWrong : ContentPage
{
    public TellIfRightOrWrong()
    {
        InitializeComponent();
        if (OnePicTwoAnswers.ChosenAnswerWasCorrect)
        {
            AnswerState.Text = "Richtig";
        }
        else
        {
            //this method-call adds the ID of the false answered questions, if it's not already included
            if (!GameService.currentUser.falseMadeQuestionsId.Contains(OnePicTwoAnswers.SavedQuiz[OnePicTwoAnswers.StaticRoundCounter].Id.ToString()))
            {
                GameService.currentUser.falseMadeQuestionsId.Add(OnePicTwoAnswers.SavedQuiz[OnePicTwoAnswers.StaticRoundCounter].Id.ToString());
            }
            AnswerState.Text = "Falsch";
        }
        FillTheRightExplaination();
        ExplainImage.Source = OnePicTwoAnswers.SavedQuiz[OnePicTwoAnswers.StaticRoundCounter].PathDermoscopy;
    }
    
    private async void GoOnButton_OnClicked(object? sender, EventArgs e)
    {
        // next question
        OnePicTwoAnswers.StaticRoundCounter++;

        // 1) check if it is the end of the quiz
        if (OnePicTwoAnswers.StaticRoundCounter >= OnePicTwoAnswers.SavedQuiz.Length)
        {
            // if quiz is done show resultPage
            await Shell.Current.GoToAsync(nameof(ResultPage1To2));
            return;
        }

        // 2) if there is another question, navigate back to quizPage
        await Shell.Current.GoToAsync(nameof(OnePicTwoAnswers));
    }


    /// <summary>
    /// choses the right answer after checking it
    /// </summary>
    private void FillTheRightExplaination()
    {
        if (OnePicTwoAnswers.SavedQuiz[OnePicTwoAnswers.StaticRoundCounter].Benigne == true)
        {
            Explaination.Text = "Diese Läsion ist Gutartig";
        }
        else
        {
            Explaination.Text = "Diese Läsion ist Maligne";
        }
    }
}