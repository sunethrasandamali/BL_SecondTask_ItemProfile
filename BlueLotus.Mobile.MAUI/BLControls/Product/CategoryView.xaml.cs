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
        model.CategoryClickEvent += Model_CategoryClickEvent; ;
        this.BindingContext = _model;
		InitializeComponent();
	}

    private async void Model_CategoryClickEvent(object sender, CategoryClickEventArgs e)
    {
		 Dispatcher.DispatchAsync(new Action(ImageButton_Clicked));
    }

    private async void ImageButton_Clicked()
	{
		if (CategoryClickEvent != null)
		{
			CategoryClickEventArgs args = new();
			args.Category = _model;

            CategoryClickEvent.Invoke(this,args );

        }
	}
}