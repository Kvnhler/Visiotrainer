using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using Visiotrainer;
using Visiotrainer.model;

namespace VisioTrainer.View;

public partial class RankingClickedPage : ContentPage
{
    public ObservableCollection<RankingEntry> RankingEntries { get; } = new();

    public RankingClickedPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadRanking();
    }

    private void LoadRanking()
    {
        RankingEntries.Clear();

        // sort the List the highest score at the first position
        var ordered = GameService.Users
            .OrderByDescending(u => u.score)                 
            .Select((user, index) => new RankingEntry
            {
                Rank = index + 1,
                UserName = user.Username,
                Score = user.score
            });

        foreach (var entry in ordered)
        {
            RankingEntries.Add(entry);
        }
    }
}