using Microsoft.Extensions.Logging;
using Stulio.Views;
using Stulio.ViewModels;
using Stulio.Services;

namespace Stulio
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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


            //Views Registration
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddTransient<AddUpdateStudentDetail>();


            //View Modles 
            builder.Services.AddSingleton<StudentListPageViewModel>();
            builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();
            return builder.Build();
        }
    }
}
