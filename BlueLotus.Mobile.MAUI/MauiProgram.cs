using BlueLotus.Mobile.MAUI.Extensions;
using BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer;
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
        Services = app.Services;
        MAUIConfiguration.configuration = app.Configuration;
        InitAPIConsumer();
        return app;

    }


    private static void InitAPIConsumer()
    {
        APISettins aPISettins = new APISettins();
        aPISettins.ApplicationId= MAUIConfiguration.configuration.GetRequiredSection("APISettings:IntegrationID").Value;      
        string SelecttedDevURL = MAUIConfiguration.configuration.GetRequiredSection("APISettings:SelectedEnviorement").Value;
        aPISettins.BaseURL= MAUIConfiguration.configuration.GetRequiredSection($"APISettings:{SelecttedDevURL}").Value;
        RestsharpAPIConsumer.Initilize(aPISettins);
    }

    public static IServiceProvider Services { get; private set; }

}
