namespace Stulio.Views;
using Stulio.ViewModels;


public partial class CommunityServiceView : ContentPage
{

    private CommunityServiceViewModel _viewMode;
    public CommunityServiceView(CommunityServiceViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetCommunityServiceListCommand.Execute(null);
    }


}