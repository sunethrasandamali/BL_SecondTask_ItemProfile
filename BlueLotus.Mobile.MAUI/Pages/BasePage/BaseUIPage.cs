using BlueLotus.Mobile.MAUI.UIBuilder;
using BlueLotus.Mobile.MAUI.ViewModels;
using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueLotus.Mobile.MAUI.Pages.BasePage
{
    public class BaseUIPage:ContentPage
    {
        protected readonly IAppObjectService _objectAppService;

        protected BaseViewModel __bindContext;
        private View _renderSpace;
        public BaseUIPage()
        {
            _objectAppService = MauiProgram.Services.GetService<IAppObjectService>();
            _renderSpace = Content;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            if (BindingContext != null && BindingContext.GetType() == typeof(UIMenu))
            {
                UIMenu menu = (UIMenu)BindingContext;
                
                Title = menu.MenuCaption;
                BindingContext = null;
                var elem = await _objectAppService.FetchObjects(menu);
                if (elem.Value != null)
                {

                    ViewGenerator vbuilder = new ViewGenerator();
                    vbuilder.Caller = this;
                    vbuilder.DataContext =__bindContext;
                    Content = vbuilder.BuildViewFromObjects(elem.Value);

                }
                BindingContext = __bindContext;
            }

            base.OnNavigatedTo(args);
        }
    }

    
}
