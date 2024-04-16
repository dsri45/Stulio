using Stulio.Views;

namespace Stulio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute("home", typeof(ProfilePage));
            Routing.RegisterRoute(nameof(ShowStudentProfile), typeof(ShowStudentProfile));
            Routing.RegisterRoute(nameof(AboutMe), typeof(AboutMe));
            Routing.RegisterRoute(nameof(AcademicAchievements), typeof(AcademicAchievements));
            Routing.RegisterRoute(nameof(ClubsAndOrganizationsView), typeof(ClubsAndOrganizationsView));
            Routing.RegisterRoute(nameof(AthleticParticipationView), typeof(AthleticParticipationView));
            Routing.RegisterRoute(nameof(CommunityServiceView), typeof(CommunityServiceView));
            Routing.RegisterRoute(nameof(WorkExperienceView), typeof(WorkExperienceView));
            Routing.RegisterRoute(nameof(AdditionalInvolvementsView), typeof(AdditionalInvolvementsView));
            Routing.RegisterRoute(nameof(AddUpdateAcademicAchievements), typeof(AddUpdateAcademicAchievements));
            Routing.RegisterRoute(nameof(AddUpdateClubsAndOrganizations), typeof(AddUpdateClubsAndOrganizations));
            Routing.RegisterRoute(nameof(AddUpdateAthleticParticipation), typeof(AddUpdateAthleticParticipation));
            Routing.RegisterRoute(nameof(AddUpdateCommunityService), typeof(AddUpdateCommunityService));
            Routing.RegisterRoute(nameof(AddUpdateWorkExperience), typeof(AddUpdateWorkExperience));
            Routing.RegisterRoute(nameof(AddUpdateAdditionalInvolvements), typeof(AddUpdateAdditionalInvolvements));
            Routing.RegisterRoute("settings", typeof(SettingsPage));

        }
    }
}
