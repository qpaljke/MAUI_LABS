using Microsoft.Extensions.Logging;
using ShukailaLabs.Services;

namespace ShukailaLabs;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddTransient<TeamPage>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
