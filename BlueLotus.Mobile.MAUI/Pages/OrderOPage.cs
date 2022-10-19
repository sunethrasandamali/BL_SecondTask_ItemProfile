using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using BlueLotus360.Data.APIConsumer.Definitions;
using BlueLotus360.Data.APIConsumer.Implementation;

namespace BlueLotus.Mobile.MAUI.Pages;

public class OrderOPage : ContentPage
{

    private readonly IAppObjectService _objectAppService
        ;


    public OrderOPage()
    {
        _objectAppService = MauiProgram.Services.GetService<IAppObjectService>();
        Title = "Purchase Order";
    

    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
    }

    protected override async  void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (BindingContext != null && BindingContext.GetType() == typeof(UIMenu))
        {
            UIMenu menu = (UIMenu)BindingContext;
            BindingContext = null;
            var elem = await _objectAppService.FetchObjects(menu);
            if (elem.Value != null)
            {
                ViewGenerator vbuilder = new ViewGenerator();
                Content = vbuilder.BuildViewFromObjects(elem.Value);

            }
        }
        
        base.OnNavigatedTo(args);
    }
}