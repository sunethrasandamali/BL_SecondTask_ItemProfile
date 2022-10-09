using BlueLotus.Mobile.MAUI.Extensions;
using Microsoft.Extensions.Configuration;
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
        builder.LoadAndInjectConfiuration();
        builder.ConfureAndroidLifeCycleEvents();
        var app = builder.Build();
        Services=app.Services;
        MAUIConfiguration.configuration = app.Configuration;
        return app ;

    }

    public static IServiceProvider Services { get; private set; }
    
}
