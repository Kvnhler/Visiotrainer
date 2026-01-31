using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visiotrainer;
using Visiotrainer.model;
using VisioTrainer.View.ControlOptions.FalseMadeQuestionControl;
using VisioTrainer.View.QuizLayouts;
using VisioTrainer.View.QuizLayouts.FivePicsTo1;
using VisioTrainer.View.QuizLayouts.OnePicTo2;

namespace VisioTrainer.View;

public partial class FalseMadeQuestions : ContentPage
{
    
    static Dermoscopy currentUsedDermoscopy;
    static DermoscopySet currentUsedDermoscopySet;
    private static bool actualLookAtMistakes;

    #region Getter and Setter

    public static Dermoscopy CurrentUsedDermoscopy
    {
        get => currentUsedDermoscopy;
    }

    public static DermoscopySet CurrentUsedDermoscopySet
    {
        get => currentUsedDermoscopySet;
    }

    public static bool ActualLookAtMistakes
    {
        get => actualLookAtMistakes;
        set => actualLookAtMistakes = value;
    }

    #endregion
    
    public FalseMadeQuestions()
    {
        InitializeComponent();
        PopulateQuestionList(GameService.currentUser.falseMadeQuestionsId);
        FivePicsOneAnswer.scoreCountAllowed = false;
    }

    /// <summary>
    /// Generates a dynamic List of all falseMadeQuestion
    /// </summary>
    /// <param name="questionIds"></param>
    public void PopulateQuestionList(List<string> questionIds)
    {
        DynamicList.Children.Clear(); // clears list at first

        foreach (string id in questionIds)
        {
            string imagePath = null;
            string textFallback = null;

            // ID ends with an "a" → OneToFourPics
            if (id.EndsWith("a"))
            {
                Dermoscopy currentDermoscopy = QuizService.OneToFourPics1
                    .FirstOrDefault(x => x.Id == id);

                if (currentDermoscopy != null)
                {
                    imagePath = currentDermoscopy.PathDermoscopy;
                }
            }
            // ID ends with a "b" → OneToTwoPics
            else if (id.EndsWith("b"))
            {
                var item = QuizService.OneToTwoPics1
                    .FirstOrDefault(x => x.Id == id);

                if (item != null)
                    imagePath = item.PathDermoscopy;
            }
            // ID ends with a "c" → FiveToOnePics → KEIN Bild, nur Text
            else if (id.EndsWith("c"))
            {
                textFallback = $"Fall-Vignette";
            }

            // VIEW-Action
            Action viewAction = () =>
            {
                Console.WriteLine($"Ansehen geklickt für {id}");
                if (id.EndsWith("a"))
                {
                    currentUsedDermoscopy = QuizService.OneToFourPics1
                        .FirstOrDefault(x => x.Id == id);
                    Shell.Current.GoToAsync(nameof(GeneralExplainationPage));
                }
                else if (id.EndsWith("b"))
                {
                    currentUsedDermoscopy = QuizService.OneToTwoPics1
                        .FirstOrDefault(x => x.Id == id);
                    Shell.Current.GoToAsync(nameof(GeneralExplainationPage));
                }
                else if (id.EndsWith("c"))
                {
                    currentUsedDermoscopySet = QuizService.FiveToOnePics1
                        .FirstOrDefault(x => x.id == id);
                    ActualLookAtMistakes = true;
                    Shell.Current.GoToAsync(nameof(FivePicsOneAnswer));
                }
            };

            // REMOVE-Action
            Action removeAction = () =>
            {
                Console.WriteLine($"Entfernen geklickt für {id}");

                // remove Id
                GameService.currentUser.falseMadeQuestionsId.Remove(id);

                // update DB
                DataBaseService.UpdateUser(GameService.currentUser);

                // rebuild List
                PopulateQuestionList(GameService.currentUser.falseMadeQuestionsId);
            };

            // If Picture available
            if (imagePath != null)
            {
                AddQuestionFrame(imagePath, viewAction, removeAction);
            }
            else
            {
                // FALL-VIGNETTE (no picture)
                AddTextFrame(textFallback, viewAction, removeAction);
            }
        }
    }

    public void AddQuestionFrame(string imagePath, Action onViewClicked, Action onRemoveClicked)
    {
        // create Picture
        var img = new Image
        {
            Source = imagePath,
            WidthRequest = 80,
            HeightRequest = 80,
            Aspect = Aspect.AspectFill
        };

        // Button „Ansehen“
        var viewButton = new Button
        {
            Text = "Ansehen",
            WidthRequest = 100,
            HeightRequest = 40
        };
        viewButton.Clicked += (s, e) => onViewClicked?.Invoke();

        // Button „Entfernen“
        var removeButton = new Button
        {
            Text = "Entfernen",
            WidthRequest = 100,
            HeightRequest = 40,
            BackgroundColor = Colors.IndianRed,
            TextColor = Colors.White
        };
        removeButton.Clicked += (s, e) => onRemoveClicked?.Invoke();

        // Horizontal Container
        var horizontalLayout = new HorizontalStackLayout
        {
            Spacing = 10,
            Children = { img, viewButton, removeButton }
        };

        // Frame
        var frame = new Frame
        {
            Content = horizontalLayout,
            Padding = 10,
            CornerRadius = 10,
            HasShadow = true,
        };

        // Add element to dynamic list
        DynamicList.Children.Add(frame);
    }

    /// <summary>
    /// Adds a new textframe if the Element is a "Fall-Vignette"
    /// </summary>
    /// <param name="text"></param>
    /// <param name="onViewClicked"></param>
    /// <param name="onRemoveClicked"></param>
    public void AddTextFrame(string text, Action onViewClicked, Action onRemoveClicked)
    {
        var label = new Label
        {
            Text = text,
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center
        };

        var viewButton = new Button
        {
            Text = "Ansehen",
            WidthRequest = 100
        };
        viewButton.Clicked += (s, e) => onViewClicked?.Invoke();

        var removeButton = new Button
        {
            Text = "Entfernen",
            WidthRequest = 100,
            BackgroundColor = Colors.IndianRed,
            TextColor = Colors.White
        };
        removeButton.Clicked += (s, e) => onRemoveClicked?.Invoke();

        var horizontal = new HorizontalStackLayout
        {
            Spacing = 10,
            Children = { label, viewButton, removeButton }
        };

        var frame = new Frame
        {
            Content = horizontal,
            Padding = 10,
            CornerRadius = 10,
            HasShadow = true
        };

        DynamicList.Children.Add(frame);
    }
}