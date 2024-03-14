using Microsoft.Extensions.Logging;
using MauiApp2.serveyer;

namespace MauiApp2
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
                    fonts.AddFont("Sansation-Light.ttf", "eng");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<GlobalStateService>();
            Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot"));


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
