namespace Stulio.Views;
using Stulio.ViewModels;

public partial class WorkExperienceView : ContentPage
{
    private WorkExperienceViewModel _viewMode;
    public WorkExperienceView(WorkExperienceViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetWorkExperienceListCommand.Execute(null);
    }
}