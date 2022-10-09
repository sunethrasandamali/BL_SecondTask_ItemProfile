using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace BlueLotus.Mobile.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var appContext = MauiProgram.Services.GetService<BLMAUIAppContext>();
        if(appContext == null && appContext.IsUserLoggedIn)
        {
            MainPage = new AppShell();
        }
        else 
        {
            MainPage = new LoginPage();

        }



    }
}
