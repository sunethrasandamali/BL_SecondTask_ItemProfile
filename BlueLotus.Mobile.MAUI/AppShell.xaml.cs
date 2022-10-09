using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;

namespace BlueLotus.Mobile.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CompanySelectionPage), typeof(CompanySelectionPage));
		var appContext = MauiProgram.Services.GetService<BLMAUIAppContext>();
		if (!appContext.IsCompleteAuthOK)
		{
		 
		}

    }
}
