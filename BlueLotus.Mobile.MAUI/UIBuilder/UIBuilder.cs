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
                    AddTextBox(verticalStackLayout, child);
                }
                if (child.ElementType != null && child.ElementType.Equals("DatePicker"))
                {
                    AddDatePicker(verticalStackLayout, child);
                }

                if (child.ElementType != null && child.ElementType.Equals("Button"))
                {
                    AddButton(verticalStackLayout, child);
                }
                if (child.ElementType != null && child.ElementType.Equals("NumericBox"))
                {
                    AddNumericBox(verticalStackLayout, child);
                }
                if (child.ElementType != null && child.ElementType.Equals("CheckBox"))
                {
                    AddCheckBox(verticalStackLayout, child);

                }

                if (child.ElementType != null && child.ElementType.Equals("ToggleButton"))
                {
                    AddSwitchBox(verticalStackLayout, child);

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

        private void AddSwitchBox(VerticalStackLayout verticalStackLayout, BLUIElement child)
        {
            var lbl = new Label();
            lbl.Text = child.ElementCaption;
            var ckBox = new Switch() { };
            ckBox.SetBinding(Switch.IsToggledProperty, child.DefaultAccessPath, BindingMode.TwoWay);
            verticalStackLayout.Children.Add(lbl);
            verticalStackLayout.Children.Add(ckBox);
        }

        private void AddCheckBox(VerticalStackLayout verticalStackLayout, BLUIElement child)
        {
            var lbl = new Label();
            lbl.Text = child.ElementCaption;           
            var ckBox = new CheckBox() { };
            ckBox.SetBinding(CheckBox.IsCheckedProperty, child.DefaultAccessPath, BindingMode.TwoWay);
            verticalStackLayout.Children.Add(lbl);
            verticalStackLayout.Children.Add(ckBox);
        }

        private void AddNumericBox(VerticalStackLayout verticalStackLayout, BLUIElement child)
        {
            var lbl = new Label();
            lbl.Text = child.ElementCaption;

            var txtFrame = new Frame()
            { };
            var txtBox = new Entry() { Keyboard = Keyboard.Numeric };
            txtBox.SetBinding(Entry.TextProperty, child.DefaultAccessPath, BindingMode.TwoWay);
            txtFrame.Content = txtBox;
            verticalStackLayout.Children.Add(lbl);
            verticalStackLayout.Children.Add(txtFrame);
        }

        private  void AddButton(VerticalStackLayout verticalStackLayout, BLUIElement child)
        {
            var button = new Button()
            {
                Text = child.ElementCaption,
              
            };
            button.SetBinding(Button.CommandProperty, child.OnClickAction, BindingMode.TwoWay);

            verticalStackLayout.Children.Add(button);
        }

        private  void AddDatePicker(VerticalStackLayout verticalStackLayout, BLUIElement child)
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

        private  void AddTextBox(VerticalStackLayout verticalStackLayout, BLUIElement child)
        {
            var lbl = new Label();
            lbl.Text = child.ElementCaption;

            var txtFrame = new Frame()
            {
          
            };
            var txtBox = new Entry() { 
            
            };
            txtBox.SetBinding(Entry.TextProperty, child.DefaultAccessPath, BindingMode.TwoWay);
            txtFrame.Content = txtBox;
            verticalStackLayout.Children.Add(lbl);
            verticalStackLayout.Children.Add(txtFrame);
        }
    }
}
