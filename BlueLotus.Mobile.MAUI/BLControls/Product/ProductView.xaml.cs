using BlueLotus.Mobile.MAUI.Events;
using BlueLotus.Mobile.MAUI.ViewModels.Category;

namespace BlueLotus.Mobile.MAUI.BLControls.Product;


public partial class ProductView : ContentView
{
    private readonly ProductViewModel _model;
  

    public event EventHandler<ProductClickEventArgs> ProductClickEvent;
    public ProductView(ProductViewModel model)
	{
        _model = model;
        this.BindingContext = _model;
        InitializeComponent();
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
        if(ProductClickEvent != null)
        {
            ProductClickEventArgs args = new ProductClickEventArgs();
            args.Product=_model;
            ProductClickEvent.Invoke(this, args);
        }
	}
}