using BlueLotus.Mobile.MAUI.ViewModels.Category;

namespace BlueLotus.Mobile.MAUI.BLControls.Product;

public partial class ProductAddRemove : ContentView
{

    private ProductViewModel product;
    private readonly ProductAddRemoveModel _model;


    public ProductViewModel Product
    {
        get
        {
            return product;
        }
        set
        {
            product= value;          
            _model.LinkedProductViewModel = product;
           _model.UpdateProdQty();
           
        }
    }

    public ProductAddRemove()
    {
        _model = new ProductAddRemoveModel();
        BindingContext= _model;
        InitializeComponent();
    }



}