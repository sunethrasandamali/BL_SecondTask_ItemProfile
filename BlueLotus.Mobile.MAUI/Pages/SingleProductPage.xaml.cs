using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus.UI.Application.Context;
using System.Reflection.Metadata.Ecma335;
using BlueLotus.Mobile.MAUI.BLControls.Product;
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
        ListProducts();
        base.OnNavigatedTo(args);
    }

    private void ListProducts()
    {
        if (SelectedProduct != null)
        {
            BindingContext = SelectedProduct;

            if (SelectedProduct.Category != null)
            {
                var appContext = MauiProgram.Services.GetService<BLUIAppContext>();
                var listProducts = appContext.FilterItemByCat(SelectedProduct.Category.CodeKey);
                _relatedProducts.Clear();
                foreach (var item in listProducts)
                {
                    ProductViewModel model = new ProductViewModel();
                    model.ProductName = item.ItemName;
                    model.SalesPrice = item.SalesPrice;
                    model.ItemKey = item.ItemKey;
                    model.ImagePathName = item.Base64ImageDocument;
                    model.Category = SelectedProduct.Category;
                    model.Description = item.Description;
                    ProductView view = new ProductView(model);
                    view.ProductClickEvent += View_ProductClickEvent;
                    _relatedProducts.Add(view);
                }
            }
        }
    }

    private void View_ProductClickEvent(object sender, Events.ProductClickEventArgs e)
    {
        SelectedProduct=e.Product;
        ListProducts();
    }
}