using BlueLotus360.Web.APIApplication;
using Microsoft.Extensions.Configuration;
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
            mauiAppBuilder.Services.AddSingleton<BLAppContext>();
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
