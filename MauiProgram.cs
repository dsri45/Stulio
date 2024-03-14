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
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // Services
            builder.Services.AddSingleton<IStudentService, StudentService>();
            builder.Services.AddSingleton<IAcademicAchievementsService, AcademicAchievementservice>();

            builder.Services.AddSingleton<LoginPage>();
            //Views Registration
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddSingleton<AddUpdateStudentDetail>();
            builder.Services.AddSingleton<AboutMe>();
            builder.Services.AddSingleton<AcademicAchievements>();
            builder.Services.AddSingleton<AddUpdateAcademicAchievements>();

            

            //View Modles 
            builder.Services.AddSingleton<StudentListPageViewModel>();
            builder.Services.AddSingleton<AboutMeViewModel>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
            builder.Services.AddSingleton<AddUpdateStudentViewModel>();
            builder.Services.AddSingleton<AcademicAchievementsViewModel>();
            builder.Services.AddSingleton<AddUpdateAcademicAchievementsViewModel>();
            



            return builder.Build();
        }
    }
}
