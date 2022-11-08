using BlueLotus.Mobile.MAUI.ViewModels.HomePage;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		var shellModel = MauiProgram.Services.GetService<AppShellModel>();
		if (shellModel != null)
		{
			shellModel.ShellTitle = "Home";
		}
		InitializeComponent();
	}

	
}

