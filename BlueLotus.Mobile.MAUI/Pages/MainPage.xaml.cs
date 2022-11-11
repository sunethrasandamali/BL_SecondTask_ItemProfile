using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class MainPage : ContentPage
{
	int count = 0;

	public IList<AddressResponse> Addresses {get; set; }	

	public MainPage()
	{
		var shellModel = MauiProgram.Services.GetService<AppShellModel>();
		if (shellModel != null)
		{
			shellModel.ShellTitle = "Home";
		}
        


        InitializeComponent();
	}

    public async void OnNoButtonClicked(object sender, EventArgs e)
	{

	}



}

