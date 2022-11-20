using BlueLotus.Mobile.MAUI.Events;
using BlueLotus.Mobile.MAUI.Pages;
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
        __addremovePanel.Clear();
        __addremovePanel.Add(new ProductAddRemove() { 
          Product=model        
        });
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        if(ProductClickEvent != null)
        {
            
            IDictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("SelectedProduct", _model);
            await Shell.Current.GoToAsync(nameof(SingleProductPage), dict);
        }
	}
}