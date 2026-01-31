using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;

namespace VisioTrainer.View.QuizLayouts.FivePicsTo1;

public partial class ExplainationFivePicsOneAnswer : ContentPage
{
    public ExplainationFivePicsOneAnswer()
    {
        InitializeComponent();
        //shows the picture by the given path
        ExplainImage.Source = getTheRightDermoscopy().PathDermoscopy;
        if (FivePicsOneAnswer.answerIsCorrect)
        {
            AnswerState.Text = "Richtig";
            Explaination.Text = "Du hast die richtige Läsion identifiziert";
        }
        else
        {
            AnswerState.Text = "Falsch";
            Explaination.Text = "Diese Läsion wäre die Maligne gewesen!";
        }

    }

    /// <summary>
    /// seaches for the dermoscopy before
    /// </summary>
    /// <returns></returns>
    private Dermoscopy getTheRightDermoscopy()
    {
        foreach (var currentQuizDermoscopy in FivePicsOneAnswer.currentQuiz.Dermoscopies)
        {
            if (currentQuizDermoscopy.Benigne)
            {
                return currentQuizDermoscopy;
            }
        }
        return null;
    }

    /// <summary>
    /// if the button is clicked, the Quiz will be reseted, and resultPage will be shown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_OnClicked(object? sender, EventArgs e)
    {
        FivePicsOneAnswer.currentQuiz = null;
        Shell.Current.GoToAsync(nameof(ResultPage5To1));
    }
}