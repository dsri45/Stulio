using Stulio.ViewModels;
using Stulio.Views;
using Stulio.Models;
using Stulio.Services;


namespace Stulio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new StudentHomePage();
            //MainPage = new LoginPage();
            UserService userservice = new UserService();
            var userViewModel = new LoginPageViewModel(userservice);
            MainPage = new NavigationPage(new LoginPage(userViewModel));
            //MainPage = new NavigationPage(new ProfilePage());

        }
    }
}
