using Stulio.ViewModels;
using Stulio.Views;

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
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new ProfilePage());

        }
    }
}
