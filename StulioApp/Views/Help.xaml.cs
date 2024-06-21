namespace Stulio.Views;
using Xamarin.Essentials;
using Microsoft.Maui.Controls;

public partial class Help : ContentPage
{
	public Help()
	{
		InitializeComponent();
	}

    private async void OnSendReportClicked(object sender, EventArgs e)
    {
        var bugDescription = BugDescriptionEditor.Text;

        if (string.IsNullOrEmpty(bugDescription))
        {
            await DisplayAlert("Error", "Please enter a bug description.", "OK");
            return;
        }

        try
        {
            var message = new EmailMessage
            {
                Subject = "Bug Report",
                Body = bugDescription,
                To = new List<string> { "dhanasriprabhu03@gmail.com" }
            };

            await Email.ComposeAsync(message);
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "Email is not supported on this device.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An unexpected error occurred: {ex.Message}", "OK");
        }
    }
}
