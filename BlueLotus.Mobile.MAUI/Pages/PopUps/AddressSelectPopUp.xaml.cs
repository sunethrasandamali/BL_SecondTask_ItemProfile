using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus360.Core.Domain.Entity.Base;
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

    private void OnYesButtonClicked(object? sender, EventArgs e)
    {
        Close(true);
    }

    private async void OnNoButtonClicked(object? sender, EventArgs e)
    {
        await _mainOrderModel.RemoveCustomerSelection();
        Close(true);
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        await _mainOrderModel.OnCustomerSelction(e.SelectedItem as AddressResponse);
    }
}