namespace Stulio.Views;
using Stulio.ViewModels;

public partial class AthleticParticipationView : ContentPage
{
    private AthleticParticipationViewModel _viewMode;
    public AthleticParticipationView(AthleticParticipationViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetAthleticParticipationListCommand.Execute(null);
    }
}