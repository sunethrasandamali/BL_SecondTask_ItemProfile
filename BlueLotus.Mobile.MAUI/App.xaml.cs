using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus360.Web.APIApplication;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace BlueLotus.Mobile.MAUI;

public partial class App : Application
{
    public App()
    {
        var AppContext = MauiProgram.Services.GetService<BLAppContext>();
        InitializeComponent();
        if(AppContext != null && AppContext.IsUserLoggedIn)
        {
            MainPage = new AppShell();
        }
        else
        {
            MainPage = new LoginPage();
        }
     

    }
}
