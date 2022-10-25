using BlueLotus.Mobile.MAUI.ViewModels.Controls.ListView;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;

namespace BlueLotus.Mobile.MAUI.BLControls.ListView;

public partial class AddressListView : ContentView
{

    public BLUIElement UIElement { get; set; }
    AddressListViewModel model;
    private TimeSpan debounceInterval;
    private DateTime PreviousChange;
    public AddressListView()
    {
        model = new AddressListViewModel();
       
        debounceInterval = new TimeSpan(0, 0, 0, 2, 750);
        PreviousChange = DateTime.Now;

        for(int i = 0; i < 10; i++)
        {
            model.Add(new AddressMaster()
            {
                AddressName= Guid.NewGuid().ToString(),
                Email= Guid.NewGuid().ToString(),
            });;
        }
        model.Finalze();
        BindingContext = model;
        InitializeComponent();

    }


    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        TimeSpan elapsed = DateTime.Now - PreviousChange;

        if (elapsed > debounceInterval)
        {
            model.Finalze();
            PreviousChange = DateTime.Now;
          
        }

    }
}