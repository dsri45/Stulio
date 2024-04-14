using Microsoft.Extensions.Logging;
using Stulio.Views;
using Stulio.ViewModels;
using Stulio.Services;
using CommunityToolkit.Maui;

namespace Stulio
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
               .UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("LeagueSpartan-Bold.ttf", "bold");
                fonts.AddFont("LeagueSpartan-Regular.ttf", "regular");
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // Services
            builder.Services.AddSingleton<IStudentService, StudentService>();
            builder.Services.AddSingleton<IAcademicAchievementsService, AcademicAchievementservice>();
            builder.Services.AddSingleton<IClubsAndOrganizationsService, ClubsAndOrganizationsService>();
            builder.Services.AddSingleton<IAthleticParticipationService, AthleticParticipationService>();
            builder.Services.AddSingleton<ICommunityServiceService, CommunityServiceService>();
            builder.Services.AddSingleton< IWorkExperienceService, WorkExperienceService>();
            builder.Services.AddSingleton<IAdditionalInvolvementsService, AdditionalInvolvementsService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<SignUpPage>();

            //Views Registration
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddSingleton<AddUpdateStudentDetail>();
            builder.Services.AddSingleton<AboutMe>();
            builder.Services.AddSingleton<AcademicAchievements>();
            builder.Services.AddSingleton<AddUpdateAcademicAchievements>();
            builder.Services.AddSingleton<ClubsAndOrganizationsView>();
            builder.Services.AddSingleton<AddUpdateClubsAndOrganizations>();
            builder.Services.AddSingleton<AthleticParticipationView>();
            builder.Services.AddSingleton<AddUpdateAthleticParticipation>();
            builder.Services.AddSingleton<CommunityServiceView>();
            builder.Services.AddSingleton<AddUpdateCommunityService>();
            builder.Services.AddSingleton<WorkExperienceView>();
            builder.Services.AddSingleton<AddUpdateWorkExperience>();
            builder.Services.AddSingleton<AdditionalInvolvementsView>();
            builder.Services.AddSingleton<AddUpdateAdditionalInvolvements>();
            builder.Services.AddSingleton<LoginPage>();



            //View Modles 
            builder.Services.AddSingleton<StudentListPageViewModel>();
            builder.Services.AddSingleton<AboutMeViewModel>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
            builder.Services.AddSingleton<AddUpdateStudentViewModel>();
            builder.Services.AddSingleton<AcademicAchievementsViewModel>();
            builder.Services.AddSingleton<AddUpdateAcademicAchievementsViewModel>();
            builder.Services.AddSingleton<ClubsAndOrganizationsViewModel>();
            builder.Services.AddSingleton<AddUpdateClubsAndOrganizationsViewModel>();
            builder.Services.AddSingleton<AthleticParticipationViewModel>();
            builder.Services.AddSingleton<AddUpdateAthleticParticipationViewModel>();
            builder.Services.AddSingleton<CommunityServiceViewModel>();
            builder.Services.AddSingleton<AddUpdateCommunityServiceViewModel > ();
            builder.Services.AddSingleton<WorkExperienceViewModel>();
            builder.Services.AddSingleton<AddUpdateWorkExperienceViewModel>();
            builder.Services.AddSingleton<AdditionalInvolvementsViewModel>();
            builder.Services.AddSingleton<AddUpdateAdditionalInvolvementsViewModel>();
            builder.Services.AddSingleton<UserViewModel>();
            builder.Services.AddSingleton<LoginPageViewModel>();



            return builder.Build();
        }
    }
}
