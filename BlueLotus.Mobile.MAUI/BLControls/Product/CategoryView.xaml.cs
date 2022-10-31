using BlueLotus.Mobile.MAUI.ViewModels.Category;

namespace BlueLotus.Mobile.MAUI.BLControls.Product;

public partial class CategoryView : ContentView
{
	private readonly CategoryViewModel _model;
    public CategoryView(CategoryViewModel model)
	{
		_model = model;

        this.BindingContext = _model;
		InitializeComponent();
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{

	}
}