using BlueLotus.Mobile.MAUI.Pages;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace BlueLotus.Mobile.MAUI;

public partial class App : Application
{
    public App()
    {

        InitializeComponent();
        
    
            MainPage = new LoginPage();
  
     

    }
}
