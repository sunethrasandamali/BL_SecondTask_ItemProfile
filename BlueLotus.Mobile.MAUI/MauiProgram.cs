using BlueLotus.Mobile.MAUI.Extensions;
using BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer;
using CommunityToolkit.Maui;
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
                fonts.AddFont("FontAwesome.otf", "FontAwesome");
            })
            
            
            ;
        builder.UseMauiCommunityToolkit();
        builder.RegisterAdditionalServices();
        builder.LoadAndInjectConfiuration();
        builder.RegisterModels();
        builder.RegisterPages();
        builder.RegisterRouting();
        builder.ConfureAndroidLifeCycleEvents();
        var app = builder.Build();
        Services = app.Services;
        MAUIConfiguration.configuration = app.Configuration;
        InitAPIConsumer();
        return app;

    }


    private static void InitAPIConsumer()
    {
      
    }

    public static IServiceProvider Services { get; private set; }

}
