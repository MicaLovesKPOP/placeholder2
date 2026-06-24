using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindBar.Core;

namespace WindBar.App.Views
{
    public sealed class StartSurface : UserControl
    {
        public StartSurface(string title, IEnumerable<AppScanner.AppInfo> apps)
        {
            var root = new StackPanel { Margin = new Thickness(24) };
            root.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 24,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 18)
            });

            var list = new ListBox
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Foreground = Brushes.White
            };
            foreach (var app in apps.Take(100).OrderBy(x => x.Group).ThenBy(x => x.Name))
            {
                list.Items.Add($"{app.Group}  •  {app.Name}");
            }
            root.Children.Add(list);
            Content = root;
        }
    }
}
