using BlueLotus.Mobile.MAUI.ViewModels.Category;
using CommunityToolkit.Maui.Views;

namespace BlueLotus.Mobile.MAUI.Pages.PopUps;

public partial class AddressSelectPopUp : Popup
{
    protected readonly MainOrderModel _mainOrderModel;

    public AddressSelectPopUp()
	{
        _mainOrderModel = MauiProgram.Services.GetService<MainOrderModel>(); 
        BindingContext = _mainOrderModel;
        InitializeComponent();
	}

    void OnYesButtonClicked(object? sender, EventArgs e) => Close(true);

    void OnNoButtonClicked(object? sender, EventArgs e) => Close(false);
}