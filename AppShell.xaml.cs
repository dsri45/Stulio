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
            Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
            Routing.RegisterRoute(nameof(AboutMe), typeof(AboutMe));
            Routing.RegisterRoute(nameof(AcademicAchievements), typeof(AcademicAchievements));
            Routing.RegisterRoute(nameof(ClubsAndOrganizationsView), typeof(ClubsAndOrganizationsView));
            Routing.RegisterRoute(nameof(AthleticParticipationView), typeof(AthleticParticipationView));
            Routing.RegisterRoute(nameof(CommunityServiceView), typeof(CommunityServiceView));
            Routing.RegisterRoute(nameof(AddUpdateAcademicAchievements), typeof(AddUpdateAcademicAchievements));
            Routing.RegisterRoute(nameof(AddUpdateClubsAndOrganizations), typeof(AddUpdateClubsAndOrganizations));
            Routing.RegisterRoute(nameof(AddUpdateAthleticParticipation), typeof(AddUpdateAthleticParticipation));
            Routing.RegisterRoute(nameof(AddUpdateCommunityService), typeof(AddUpdateCommunityService));
            Routing.RegisterRoute("settings", typeof(SettingsPage));

        }
    }
}
