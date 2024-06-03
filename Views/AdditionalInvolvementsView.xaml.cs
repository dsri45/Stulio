namespace Stulio.Views;
using Stulio.ViewModels;
using System;

public partial class AdditionalInvolvementsView : ContentPage
{
    private AdditionalInvolvementsViewModel _viewMode;
    public AdditionalInvolvementsView(AdditionalInvolvementsViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetAdditionalInvolvementsListCommand.Execute(null);
    }
}