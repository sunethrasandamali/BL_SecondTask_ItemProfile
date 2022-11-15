using BlueLotus.Mobile.MAUI.BLControls.Product;
using BlueLotus.Mobile.MAUI.Pages.BasePage;
using BlueLotus.Mobile.MAUI.Pages.PopUps;
using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

namespace BlueLotus.Mobile.MAUI.Pages;

[QueryProperty("Menu", "Menu")]
public partial class MainOrderPage : ContentPage
{
    protected BaseViewModel __bindContext;
    protected readonly IAppObjectService _objectAppService;
    protected readonly ICodeBaseService _codeBaseService;
    protected readonly MainOrderModel _mainOrderModel;

    private BLUIElement _categoryPage;
    private BLUIElement _orderPage;
    private BLUIElement _customerPage;
    private CategoryViewModel SelectedCategory;
    public UIMenu Menu { get; set; }

    public MainOrderPage()
    {
        _objectAppService = MauiProgram.Services.GetService<IAppObjectService>();
        _codeBaseService = MauiProgram.Services.GetService<ICodeBaseService>();
        _mainOrderModel = MauiProgram.Services.GetService<MainOrderModel>(); ;
        this.BindingContext = _mainOrderModel;

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
                var width = 400;
                __categoryPage.Clear();
                foreach (var item in items.Value)
                {
                    CategoryViewModel model = new CategoryViewModel();
                    model.CodeKey = item.CodeKey;
                    model.CategoryName = item.CodeName;
                    model.ImagePathName = string.IsNullOrWhiteSpace(item.CodeExtraCharacter1) ? "no_image.png" : item.CodeExtraCharacter1;
                    var catm = new CategoryView(model);
                    catm.WidthRequest = width * 0.97;
                    catm.CategoryClickEvent += Catm_CategoryClickEvent;
                    __categoryPage.Add(
                      catm
                        );
                }
            }
        }
    }

    private async void Catm_CategoryClickEvent(object sender, Events.CategoryClickEventArgs e)
    {
        SelectedCategory = e.Category;
        SelectedCategoryName.Text = "Products Under Category - " + SelectedCategory.CategoryName + ".";
  
        __productPage.IsVisible = true;
        __categoryPage.IsVisible = false;
        await LoadProducts();
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {

        base.OnNavigatingFrom(args);
    }

    private async Task LoadProducts()
    {
        var appContext = MauiProgram.Services.GetService<BLUIAppContext>();
        var listProducts = appContext.FilterItemByCat(SelectedCategory.CodeKey);
        SelectedCategoryName.Text = $"Products Under Category - {SelectedCategory.CategoryName} ({listProducts.Count})";
        __productListView.Clear();
        foreach (var item in listProducts)
        {
            ProductViewModel model = new ProductViewModel();
            model.ProductName = item.ItemName;
            model.SalesPrice = item.SalesPrice;
            model.ItemKey = item.ItemKey;
            model.ImagePathName = item.Base64ImageDocument;
            ProductView view = new ProductView(model);
            view.ProductClickEvent += View_ProductClickEvent;
            __productListView.Add(view);
        }
        await Task.CompletedTask;
    }

    private async void View_ProductClickEvent(object sender, Events.ProductClickEventArgs e)
    {
        ProductViewModel m = e.Product;
        IDictionary<string, object> dict = new Dictionary<string, object>();
         dict.Add("SelectedProduct", m);
         await Shell.Current.GoToAsync(nameof(SingleProductPage), dict);
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {


        if (Menu == null && BindingContext != null && BindingContext.GetType() == typeof(UIMenu))
        {
            Menu = (UIMenu)BindingContext;
            BindingContext = null;
            BindingContext = __bindContext;
        }


        if (Menu != null)
        {
            var shellModel = MauiProgram.Services.GetService<AppShellModel>();
            if (shellModel != null)
            {
                shellModel.ShellTitle = Menu.MenuCaption;
            }

            var elem = await _objectAppService.FetchObjects(Menu);
            foreach (var obj in elem.Value.Children)
            {
                if (obj.ElementName.Equals("__ProductsPage__"))
                {
                    _categoryPage = obj;
                }
            }
        }

        base.OnNavigatedTo(args);

        await ReadCategories();
    }


    protected async void OnBackButtonClicked(object sender, EventArgs args)
    {
        SelectedCategory = null;
        __productPage.IsVisible = false;
        __categoryPage.IsVisible = true;
        __categoryPage.FadeTo(1);
        await __categoryPage.RotateXTo(0);

    }

    protected async void OnCustomerSelectClick(object sender, EventArgs args)
    {


        AddressSelectPopUp pop = new AddressSelectPopUp();
        this.ShowPopup(pop);

    }


}