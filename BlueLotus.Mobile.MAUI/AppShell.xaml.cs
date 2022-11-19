
using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.Mobile.MAUI.ViewModels.HomePage;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;


namespace BlueLotus.Mobile.MAUI;

public partial class AppShell : Shell
{
    IAppObjectService _appObjectService;
    AppShellModel _shellModel;
    public AppShell(IAppObjectService appObject,AppShellModel shellModel)
    {
        _shellModel= shellModel;
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
            shellModel.ShellAvatarText = appContext.ApplicationUser.UserID.Substring(0, 2).ToUpper();
        }


        InitializeComponent();
        SideMenu();
    }

    public async void SideMenu()
    {
        _shellModel.LoadProgress = 0.3;
        BaseServerResponse<UIMenu> men = await _appObjectService.FetchSideMenu();
        UIMenu DefaultMenu = null;
        var mobmenu = men.Value.SubMenus.Where(x => x.MenuName.Equals("__MB_MENU_ENTRY__")).FirstOrDefault();
        if (mobmenu != null)
        {
            int outV;
            foreach (UIMenu menu in mobmenu.SubMenus)
            {
                Type pageType = GetPageByName(menu.MenuName);
                if (pageType != null)
                {
                   int.TryParse(menu.MenuIcon, System.Globalization.NumberStyles.AllowHexSpecifier,
    System.Globalization.CultureInfo.InvariantCulture, out outV);
                    if (menu.MenuName.Equals("MainOrderPage"))
                    {
                        DefaultMenu = menu;
                    }
                    var unicodeValue = (char)outV;
                    Items.Add((new ShellContent()
                    {
                        Title = menu.MenuCaption,
                        ContentTemplate = new DataTemplate(pageType),
                        BindingContext = menu,
                        
                        Icon= new FontImageSource()
                        {
                            FontFamily = "FontAwesome",
                            Glyph= unicodeValue.ToString(),
                            Size =20,
                            Color=Color.FromRgb(0,0,0),

                        }
                       



                    }));
                }
               

            }
        }
        if (DefaultMenu != null)
        {
           IDictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Menu", DefaultMenu);
            _shellModel.LoadProgress = 0.7;
            await Task.Delay(300);
            _shellModel.LoadProgress = 0.9;
            await Task.Delay(100);
              await Shell.Current.GoToAsync(DefaultMenu.MenuName, dict);
            //MainOrderPage p = new MainOrderPage();
            //p.Menu = DefaultMenu;
            //Navigation.PushModalAsync(p);
        }
       
  
        



    }

    private Type GetPageByName(string pageName)
    {
        string @namespace = "BlueLotus.Mobile.MAUI.Pages";
        var myClassType = Type.GetType(String.Format("{0}.{1}", @namespace, pageName));
        if (myClassType != null) {
            Routing.RegisterRoute(pageName, myClassType);
        }
        return myClassType;
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
