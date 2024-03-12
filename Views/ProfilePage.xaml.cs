using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class ProfilePage : ContentPage
    {
        private ProfilePageViewModel _viewMode;
        public ProfilePage(ProfilePageViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewMode.LoadByStudentIDCommand.Execute(null);

            //// Save student ID after successful login
            //Application.Current.Properties["StudentID"] = yourStudentID;

            //// Retrieve student ID elsewhere in the app
            //var studentID = (string)Application.Current.Properties["StudentID"];
        }
        private void CloseAboutMe(object sender, EventArgs e)
        {
            aboutMeFrame.IsVisible = true;
        }

        

    }
}


