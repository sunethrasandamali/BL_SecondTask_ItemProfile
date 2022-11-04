using BlueLotus.Mobile.MAUI.Events;
using BlueLotus.Mobile.MAUI.ViewModels.Category;

namespace BlueLotus.Mobile.MAUI.BLControls.Product;

public partial class CategoryView : ContentView
{
	private readonly CategoryViewModel _model;

	public event EventHandler<CategoryClickEventArgs> CategoryClickEvent;
    public CategoryView(CategoryViewModel model)
	{
		_model = model;

        this.BindingContext = _model;
		InitializeComponent();
	}

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		if (CategoryClickEvent != null)
		{
			CategoryClickEventArgs args = new();
			args.Category = _model;

            CategoryClickEvent.Invoke(this,args );

        }
	}
}