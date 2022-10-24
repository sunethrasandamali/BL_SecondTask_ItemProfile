using BlueLotus.Mobile.MAUI.Pages.BasePage;
using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using BlueLotus360.Data.APIConsumer.Definitions;
using BlueLotus360.Data.APIConsumer.Implementation;

namespace BlueLotus.Mobile.MAUI.Pages;

public class CustomerPage : BaseUIPage
{
    



    public CustomerPage()
    {
        __bindContext = new CustomerPageModel() { ApplicationName = "I See" ,CustomerDate=new DateTime(2000,10,10)};
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
    }


}