using BlueLotus360.Core.Domain.Entity.Object;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.UIBuilder
{
    internal class ViewGenerator
    {

        public object DataContext { get; set; }

        public ContentPage Caller { get; set; }
        public View BuildViewFromObjects(BLUIElement elem)
        {
            Grid grid = new Grid();
            grid.BindingContext = DataContext;
            VerticalStackLayout verticalStackLayout = new VerticalStackLayout();
            verticalStackLayout.Padding = new Thickness(10);

            foreach (BLUIElement child in elem.Children)
            {
                if (child.ElementType != null && child.ElementType.Equals("TextBox"))
                {
                    var lbl = new Label();
                    lbl.Text = child.ElementCaption;
                    
                    var txtFrame = new Frame()
                    { };
                    var txtBox = new Entry() { };
                    txtBox.SetBinding(Entry.TextProperty, child.DefaultAccessPath, BindingMode.TwoWay);
                    txtFrame.Content = txtBox;
                    verticalStackLayout.Children.Add(lbl);
                    verticalStackLayout.Children.Add(txtFrame);
                }
                if (child.ElementType != null && child.ElementType.Equals("DatePicker"))
                {
                    var lbl = new Label();
                    lbl.Text = child.ElementCaption;
                    var txtFrame = new Frame()
                    { };
                    var datePicker = new DatePicker() { };
                    datePicker.SetBinding(DatePicker.DateProperty, child.DefaultAccessPath, BindingMode.TwoWay);
                    txtFrame.Content = datePicker;
                    verticalStackLayout.Children.Add(lbl);
                    verticalStackLayout.Children.Add(txtFrame);
                }

                if (child.ElementType != null && child.ElementType.Equals("Button"))
                {
                    
               
                    var button = new Button() {
                    Text = child.ElementCaption,
                    };
                    button.SetBinding(Button.CommandProperty, child.OnClickAction, BindingMode.TwoWay);                   
                   
                    verticalStackLayout.Children.Add(button);
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
