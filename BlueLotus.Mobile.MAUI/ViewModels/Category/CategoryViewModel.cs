using BlueLotus.Mobile.MAUI.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Category
{
    public partial class CategoryViewModel: BaseViewModel
    {
        public event EventHandler<CategoryClickEventArgs> CategoryClickEvent;
        [ObservableProperty]
        private string categoryName;

        [ObservableProperty]
        private string imagePathName;

        [ObservableProperty]
        private long codeKey;


        [RelayCommand]
        private async  void OnCatClick()
        {
            if (CategoryClickEvent != null)
            {
                CategoryClickEventArgs args = new();
                args.Category = this;
                //  CategoryClickEvent.BeginInvoke(this, args,null,null);
                CategoryClickEvent.Invoke(this, args);
            }

        }

       

        void Send()
        {
           
        }

    }
}
