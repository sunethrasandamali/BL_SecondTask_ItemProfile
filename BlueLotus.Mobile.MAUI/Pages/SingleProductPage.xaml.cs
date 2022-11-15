using BlueLotus.Mobile.MAUI.ViewModels.Category;
using System.Reflection.Metadata.Ecma335;

namespace BlueLotus.Mobile.MAUI.Pages;

[QueryProperty("SelectedProduct", "SelectedProduct")]
public partial class SingleProductPage : ContentPage
{

	public ProductViewModel SelectedProduct { get; set; }
	public SingleProductPage()
	{
		

        InitializeComponent();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{ 
		if (SelectedProduct != null)
		{
		
		}
		base.OnNavigatedTo(args);
	}


}