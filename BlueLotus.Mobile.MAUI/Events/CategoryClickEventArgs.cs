using BlueLotus.Mobile.MAUI.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.Events
{
    public class CategoryClickEventArgs:EventArgs
    {   
        public CategoryViewModel Category { get; set; }
    }
}
