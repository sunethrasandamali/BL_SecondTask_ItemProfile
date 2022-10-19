
using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using static Android.Net.LocalSocketAddress;

namespace BlueLotus.Mobile.MAUI;

public partial class AppShell : Shell
{
    IAppObjectService _appObjectService;
    public AppShell(IAppObjectService appObject,AppShellModel shellModel)
    {
        BindingContext = shellModel;
        _appObjectService = appObject;
        Routing.RegisterRoute(nameof(CompanySelectionPage), typeof(CompanySelectionPage));
        var appContext = MauiProgram.Services.GetService<BLUIAppContext>();
        if (!appContext.IsCompleteAuthOK)
        {

        }
        else
        {
            shellModel.ShellUser = appContext.ApplicationUser.UserID;
            shellModel.ShellCompany = appContext.ApllicationCompany.CompanyName;

        }


        InitializeComponent();
        SideMenu();
    }

    public async void SideMenu()
    {
        BaseServerResponse<UIMenu> men = await _appObjectService.FetchSideMenu();

        var mobmenu = men.Value.SubMenus.Where(x => x.MenuName.Equals("__MB_MENU_ENTRY__")).FirstOrDefault();
        if (mobmenu != null)
        {
            foreach (UIMenu menu in mobmenu.SubMenus)
            {
                Type pageType = GetPageByName(menu.MenuName);
                if (pageType != null)
                {
                    Items.Add((new ShellContent()
                    {
                        Title = menu.MenuCaption,
                        ContentTemplate = new DataTemplate(pageType),
                        BindingContext = menu



                    }));
                }
               

            }
        }



    }

    private Type GetPageByName(string pageName)
    {
        string @namespace = "BlueLotus.Mobile.MAUI.Pages";
        var myClassType = Type.GetType(String.Format("{0}.{1}", @namespace, pageName));
        return myClassType;
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
