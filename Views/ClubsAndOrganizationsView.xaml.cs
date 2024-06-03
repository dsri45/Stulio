namespace Stulio.Views;
using Stulio.ViewModels;


public partial class ClubsAndOrganizationsView : ContentPage
{

    private ClubsAndOrganizationsViewModel _viewMode;
    public ClubsAndOrganizationsView(ClubsAndOrganizationsViewModel viewModel)
	{
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetClubsAndOrganizationsListCommand.Execute(null);
    }


}