using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Category
{
    public partial class CategoryViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string categoryName;

        [ObservableProperty]
        private string imagePathName;

        [ObservableProperty]
        private long codeKey;
    }
}
