using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class OrderSummaryPage : ContentPage
{

    private readonly AppShellModel shellModel;
    private readonly MainOrderModel model;


    public OrderSummaryPage()
	{
        shellModel=MauiProgram.Services.GetService<AppShellModel>();
        model = MauiProgram.Services.GetService<MainOrderModel>();
        BindingContext = model;
		shellModel.ShellTitle = "Order Summary";

        InitializeComponent();
	}

    private  async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       await  model.OnCustomerSelction(e.SelectedItem as AddressResponse);
    }
}