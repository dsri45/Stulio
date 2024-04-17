
namespace Stulio.Views;
using Stulio.ViewModels;


public partial class PersonalEndeavorsView : ContentPage
{

    private PersonalEndeavorsViewModel _viewMode;
    public PersonalEndeavorsView(PersonalEndeavorsViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetPersonalEndeavorsListCommand.Execute(null);
    }


}