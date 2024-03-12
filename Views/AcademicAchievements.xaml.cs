
using Stulio.ViewModels;

namespace Stulio.Views;

public partial class AcademicAchievements : ContentPage
{
	public AcademicAchievements(AcademicAchievementsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void SelectBarcode(object sender, EventArgs e)
    {
        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Your Favourite picture",
            FileTypes = FilePickerFileType.Images
        });
        var imageSource = images.FullPath.ToString();
        barcodeImage.Source = imageSource;
        outputText.Text = imageSource;
    }

}