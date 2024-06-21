using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class ShowStudentProfile : ContentPage
    {
        private readonly ShowStudentProfileViewModel _viewModel;
        public ShowStudentProfile(ShowStudentProfileViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadRecords();
        }

        private void ScrollToClasses(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(ClassesNav, ScrollToPosition.Start, true);
        }

        private void ScrollToAcademicAchivements(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(AcademicAchievementsNav, ScrollToPosition.Start, true);
        }

        private void ScrollToClubsAndOrganizations(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(ClubsAndOrganizationsNav, ScrollToPosition.Start, true);
        }

        private void ScrollToCommunityService(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(CommunityServiceNav, ScrollToPosition.Start, true);
        }

        private void ScrollToAthleticParticipation(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(AthleticParticipationNav, ScrollToPosition.Start, true);
        }

        private void ScrollToWorkExperience(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(WorkExperienceNav, ScrollToPosition.Start, true);
        }

        private void ScrollToPersonalEndeavors(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(PersonalEndeavorsNav, ScrollToPosition.Start, true);
        }

        private void ScrollToAdditionalInvolvements(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(AdditionalInvolvementsNav, ScrollToPosition.Start, true);
        }

        private void ScrollToTop(object sender, EventArgs e)
        {
            scrollView.ScrollToAsync(0, 0, true);
        }

    }
}