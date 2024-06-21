namespace Stulio.Views;
using Stulio.ViewModels;


public partial class ClassesView : ContentPage
{

    private ClassesViewModel _viewMode;
    public ClassesView(ClassesViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetClassesListCommand.Execute(null);
    }


}