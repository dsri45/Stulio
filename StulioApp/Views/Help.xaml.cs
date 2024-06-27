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

    private void OnLabelTapped(object sender, EventArgs e)
    {
        // URL you want to navigate to
        string url = "https://sway.cloud.microsoft/alwvbN8IahMV9jpz?ref=Link"; // Replace with your actual URL

        // Open the URL in the default web browser
        try
        {
            Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // Handle any errors that might occur during the opening of the URL
            DisplayAlert("Error", $"Unable to open URL: {ex.Message}", "OK");
        }
    }
}
