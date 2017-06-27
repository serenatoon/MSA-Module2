using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Module2
{
    public class Grid1 : ContentPage
    {
        int count = 1;

        public Grid1()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 20
            };

            var grid = new Grid
            {
                RowSpacing = 50
            };

            grid.Children.Add(new Xamarin.Forms.Label { Text = "This" }, 0, 0); // Left, First element
            grid.Children.Add(new Xamarin.Forms.Label { Text = "text is" }, 1, 0); // Right, First element
            grid.Children.Add(new Xamarin.Forms.Label { Text = "in a" }, 0, 1); // Left, Second element
            grid.Children.Add(new Xamarin.Forms.Label { Text = "grid!" }, 1, 1); // Right, Second element

            var gridButton = new Button { Text = "So is this Button!\nClick me." };
            gridButton.Clicked += delegate
            {
                gridButton.Text = string.Format("Thanks! {0} clicks.", count++);
            };

            layout.Children.Add(grid);
            layout.Children.Add(gridButton);
            Content = layout;

        }
    }
}
