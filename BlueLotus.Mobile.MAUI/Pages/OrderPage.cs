using BlueLotus.Mobile.MAUI.Pages.BasePage;

namespace BlueLotus.Mobile.MAUI.Pages;

public class OrderPage : BaseUIPage
{
	public OrderPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}