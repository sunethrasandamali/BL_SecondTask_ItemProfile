using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.UI.Application.Context;

namespace BlueLotus.Mobile.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CompanySelectionPage), typeof(CompanySelectionPage));
		var appContext = MauiProgram.Services.GetService<BLUIAppContext>();
		if (!appContext.IsCompleteAuthOK)
		{
		 
		}

    }
}
