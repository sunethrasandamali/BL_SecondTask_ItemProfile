﻿using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace BlueLotus.Mobile.MAUI;

public partial class App : Application
{
    public App(BLMAUIAppContext appContext)
    {
        InitializeComponent();
        
        if (appContext == null && appContext.IsUserLoggedIn)
        {
            MainPage = MauiProgram.Services.GetService<AppShell>();
        }
        else 
        {
          MainPage = MauiProgram.Services.GetService<LoginPage>();


        }



    }
}
