
using Stulio.ViewModels;

namespace Stulio.Views;

public partial class AcademicAchievements : ContentPage
{

    private AcademicAchievementsViewModel _viewMode;
    public AcademicAchievements(AcademicAchievementsViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetAcademicAchievementsListCommand.Execute(null);
    }
   

    //private async void SelectBarcode(object sender, EventArgs e)
    //{
    //    var images = await FilePicker.Default.PickAsync(new PickOptions
    //    {
    //        PickerTitle = "Pick Your Favourite picture",
    //        FileTypes = FilePickerFileType.Images
    //    });
    //    var imageSource = images.FullPath.ToString();
    //    barcodeImage.Source = imageSource;
    //    outputText.Text = imageSource;
    //}

    

}