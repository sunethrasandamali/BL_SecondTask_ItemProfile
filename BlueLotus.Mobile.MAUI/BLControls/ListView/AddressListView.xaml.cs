using BlueLotus.Mobile.MAUI.ViewModels.Controls.ListView;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;

namespace BlueLotus.Mobile.MAUI.BLControls.ListView;

public partial class AddressListView : ContentView
{

	public BLUIElement UIElement { get; set; }
	public AddressListView()
	{
		AddressListViewModel model = new AddressListViewModel();
		BindingContext = model;
		model.Addresses.Add(new AddressMaster()
		{
			AddressName="Reyal",
			AddressId= "RE",
			Email= "hirashriyal@outlook.com"

        });

        InitializeComponent();
	}
}