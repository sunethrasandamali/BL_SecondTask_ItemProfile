using BlueLotus360.Core.Domain.Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.UIBuilder
{
    internal class ViewGenerator
    {
        public View BuildViewFromObjects(BLUIElement elem)
        {
            Grid grid = new Grid();
            VerticalStackLayout verticalStackLayout = new VerticalStackLayout();
            verticalStackLayout.Padding = new Thickness(10);

            foreach (BLUIElement child in elem.Children)
            {
                if (child.ElementType != null && child.ElementType.Equals("TextBox"))
                {

                    var lbl = new Label();
                    lbl.Text = child.ElementCaption;
                    var txtFrame = new Frame()
                    {

                    };
                    var txtBox = new Entry() { Text = child.DefaultValue, };
                    txtFrame.Content = txtBox;
                    verticalStackLayout.Children.Add(lbl);
                    verticalStackLayout.Children.Add(txtFrame);

                }
            }

            grid.Add(verticalStackLayout);

            //var grid=    new VerticalStackLayout
            //      {
            //          Children = {
            //          new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "We Rocks!"
            //          }
            //      }
            //      };

            return grid;
        }
    }
}
