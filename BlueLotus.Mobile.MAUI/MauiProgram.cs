using BlueLotus.Mobile.MAUI.Extensions;
using Microsoft.Maui.LifecycleEvents;

namespace BlueLotus.Mobile.MAUI;

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

        builder.RegisterAdditionalServices();
        var app = builder.Build();
        Services=app.Services;
        return app ;

    }

    public static IServiceProvider Services { get; private set; }
}
