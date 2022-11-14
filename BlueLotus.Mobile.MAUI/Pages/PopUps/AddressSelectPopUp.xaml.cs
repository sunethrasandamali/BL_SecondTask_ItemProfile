using CommunityToolkit.Maui.Views;

namespace BlueLotus.Mobile.MAUI.Pages.PopUps;

public partial class AddressSelectPopUp : Popup
{
	public AddressSelectPopUp()
	{
		InitializeComponent();
	}

    void OnYesButtonClicked(object? sender, EventArgs e) => Close(true);

    void OnNoButtonClicked(object? sender, EventArgs e) => Close(false);
}