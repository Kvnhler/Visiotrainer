using VisioTrainer.View;
using VisioTrainer.View.ControlOptions.FalseMadeQuestionControl;
using VisioTrainer.View.QuizLayouts;
using VisioTrainer.View.QuizLayouts.FivePicsTo1;
using VisioTrainer.View.QuizLayouts.OnePicTo2;
using VisioTrainer.View.UserValidation;
using VisioTrainer.ViewModel;

namespace Visiotrainer;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        //this registrates all pages included in the application
        Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
        Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        Routing.RegisterRoute(nameof(SignOutPage), typeof(SignOutPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(MainMenuPage), typeof(MainMenuPage));
        Routing.RegisterRoute(nameof(QuizClickedPage), typeof(QuizClickedPage));
        Routing.RegisterRoute(nameof(FalseMadeQuestions), typeof(FalseMadeQuestions));
        Routing.RegisterRoute(nameof(RankingClickedPage), typeof(RankingClickedPage));
        Routing.RegisterRoute(nameof(ExplainationPage1To4), typeof(ExplainationPage1To4));
        Routing.RegisterRoute(nameof(ExplainationFivePicsOneAnswer),typeof(ExplainationFivePicsOneAnswer));
        Routing.RegisterRoute(nameof(FivePicsOneAnswer), typeof(FivePicsOneAnswer));
        Routing.RegisterRoute(nameof(OnePicFourAnswers), typeof(OnePicFourAnswers));
        Routing.RegisterRoute(nameof(OnePicTwoAnswers), typeof(OnePicTwoAnswers));
        Routing.RegisterRoute(nameof(TellIfRightOrWrong), typeof(TellIfRightOrWrong));
        Routing.RegisterRoute(nameof(ResultPage1To2), typeof(ResultPage1To2));
        Routing.RegisterRoute(nameof(ResultPage1To4), typeof(ResultPage1To4));
        Routing.RegisterRoute(nameof(ResultPage5To1), typeof(ResultPage5To1));
        Routing.RegisterRoute(nameof(GeneralExplainationPage), typeof(GeneralExplainationPage));
        
        // this method-call loads all users to the GameService.user list
        DataBaseService.LoadAllUsers();
        
        // this calls the method that instatiates the whole quizpictures
        QuizService.InitializeTestQuizPictures();
    }
}