using BlueLotus.Mobile.MAUI.Pages.BasePage;
using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class MainOrderPage : ContentPage
{
    protected BaseViewModel __bindContext;
    protected readonly IAppObjectService _objectAppService;

    public MainOrderPage()
    {
        _objectAppService = MauiProgram.Services.GetService<IAppObjectService>();

        __bindContext = new();
        InitializeComponent();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (BindingContext != null && BindingContext.GetType() == typeof(UIMenu))
        {
            UIMenu menu = (UIMenu)BindingContext;

            Title = menu.MenuCaption;
            BindingContext = null;
            var elem = await _objectAppService.FetchObjects(menu);
          
            BindingContext = __bindContext;
        }

        base.OnNavigatedTo(args);
    }

}