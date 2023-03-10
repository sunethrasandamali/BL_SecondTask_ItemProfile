using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using BlueLotus.UI.Application;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus.UI.Application.Services.Implementation;
using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.LifecycleEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.Extensions
{
    public static class ServiceBuilder
    {
        public static MauiAppBuilder RegisterAdditionalServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<BLUIAppContext>();
            mauiAppBuilder.Services.AddSingleton<AppStaurtUp>();
   
            mauiAppBuilder.Services.AddSingleton<IAppUserService,AppUserService>();
            mauiAppBuilder.Services.AddSingleton<IAppObjectService, AppObjectService>();
            mauiAppBuilder.Services.AddSingleton<ICodeBaseService, CodeBaseService>();
            mauiAppBuilder.Services.AddSingleton<IAppAddressService, AppAddressService>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<MainPage>();
            mauiAppBuilder.Services.AddScoped<AppShell>();
            mauiAppBuilder.Services.AddScoped<LoginPage>();
            mauiAppBuilder.Services.AddTransient<CompanySelectionPage>();
           // mauiAppBuilder.Services.AddSingleton<ProductListPage>();
            //mauiAppBuilder.Services.AddScoped<ProductListPage>();
           
        
       
            return mauiAppBuilder;
        }


        public static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<UserLoginModel>();
            mauiAppBuilder.Services.AddTransient<CompanySelectionModel>();
            mauiAppBuilder.Services.AddSingleton<AppShellModel>();
            mauiAppBuilder.Services.AddSingleton<MainOrderModel>();
            mauiAppBuilder.Services.AddSingleton<BaseViewModel>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterRouting(this MauiAppBuilder mauiAppBuilder)
        {
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CompanySelectionPage), typeof(CompanySelectionPage));
            Routing.RegisterRoute(nameof(SingleProductPage), typeof(SingleProductPage));
            Routing.RegisterRoute(nameof(ProductListPage), typeof(ProductListPage));
            Routing.RegisterRoute(nameof(OrderSummaryPage), typeof(OrderSummaryPage));
            return mauiAppBuilder;
        }

        public static MauiAppBuilder LoadAndInjectConfiuration(this MauiAppBuilder mauiAppBuilder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("BlueLotus.Mobile.MAUI.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            mauiAppBuilder.Configuration.AddConfiguration(config);
           // mauiAppBuilder.Services.AddSingleton<IConfiguration,MAUIConfiguration >();



            return mauiAppBuilder;
        }

        public static MauiAppBuilder ConfureAndroidLifeCycleEvents(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.ConfigureLifecycleEvents(events =>
            {
                #if ANDROID
                                events.AddAndroid(android => android
                                    .OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                                {
                                    
                                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Black);
                                }
                #endif
            });

            return mauiAppBuilder;
        }

    }
}
