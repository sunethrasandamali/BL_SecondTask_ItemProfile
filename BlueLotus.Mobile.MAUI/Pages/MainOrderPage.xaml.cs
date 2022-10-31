using BlueLotus.Mobile.MAUI.BLControls.Product;
using BlueLotus.Mobile.MAUI.Pages.BasePage;
using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class MainOrderPage : ContentPage
{
    protected BaseViewModel __bindContext;
    protected readonly IAppObjectService _objectAppService;
    protected readonly ICodeBaseService _codeBaseService;

    private BLUIElement _categoryPage;
    private BLUIElement _orderPage;
    private BLUIElement _customerPage;
        

    public MainOrderPage()
    {
        _objectAppService = MauiProgram.Services.GetService<IAppObjectService>();
        _codeBaseService = MauiProgram.Services.GetService<ICodeBaseService>();
        __bindContext = new();
        InitializeComponent();
	}
    private async Task ReadCategories()
    {
        if (_categoryPage != null)
        {
            ComboRequestDTO dto = new ComboRequestDTO();
            dto.RequestingElementKey = (int)_categoryPage.ElementKey;
            var items = await _codeBaseService.ReadProductCategories(dto);
            if (items.Value != null)
            {
                foreach(var item in items.Value)
                {
                    CategoryViewModel model = new CategoryViewModel();
                    model.CodeKey = item.CodeKey;
                    model.CategoryName = item.CodeName;
                    model.ImagePathName = string.IsNullOrWhiteSpace(item.CodeExtraCharacter1) ? "no_image.png": item.CodeExtraCharacter1;
                    __categoryPage.Add(
                        new CategoryView(model)
                        ) ;
                }
            }
        }
    }


    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (BindingContext != null && BindingContext.GetType() == typeof(UIMenu))
        {
            UIMenu menu = (UIMenu)BindingContext;

            Title = menu.MenuCaption;
            BindingContext = null;
            var elem = await _objectAppService.FetchObjects(menu);
            foreach(var obj in elem.Value.Children)
            {
                if (obj.ElementName.Equals("__ProductsPage__"))
                {
                    _categoryPage = obj;
                }
            }
            BindingContext = __bindContext;
        }
        base.OnNavigatedTo(args);

        await ReadCategories();
    }


 

}