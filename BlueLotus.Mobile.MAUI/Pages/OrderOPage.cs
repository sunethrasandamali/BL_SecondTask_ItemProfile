namespace BlueLotus.Mobile.MAUI.Pages;

public class OrderOPage : ContentPage
{
	public OrderOPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Button { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}