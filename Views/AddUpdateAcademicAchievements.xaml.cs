using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateAcademicAchievements : ContentPage
    {
        public AddUpdateAcademicAchievements(AddUpdateAcademicAchievementsViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}