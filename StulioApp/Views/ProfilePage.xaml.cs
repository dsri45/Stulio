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
          
            // Retrieve UserID
            var UserID = Preferences.Get("UserID", 999);

            _viewMode.LoadByStudentIDCommand.Execute(UserID);

            //// Save student ID after successful login
            //Application.Current.Properties["StudentID"] = yourStudentID;

           
        }
        private void CloseAboutMe(object sender, EventArgs e)
        {
            aboutMeFrame.IsVisible = true;
        }

        

    }
}


