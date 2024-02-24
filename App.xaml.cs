using Stulio.View;

namespace Stulio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new StudentHomePage();
            //MainPage = new LoginPage(); 
        }
    }
}
