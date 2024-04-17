using Stulio.ViewModels;

namespace Stulio.Views;

public partial class FourmPage : ContentPage
{
    private readonly ForumPageViewModel _viewModel;
    public FourmPage(ForumPageViewModel viewModel)
	{
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.CallChatGPT();
    }
}

