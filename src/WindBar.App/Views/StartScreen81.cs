using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindBar.Core;

namespace WindBar.App.Views
{
    public sealed class StartScreen81 : UserControl, IStartMenuProvider
    {
        public StartScreen81()
        {
            var panel = new WrapPanel { Margin = new Thickness(32) };
            panel.Children.Add(Tile("Desktop"));
            panel.Children.Add(Tile("Files"));
            panel.Children.Add(Tile("Browser"));
            panel.Children.Add(Tile("Settings"));
            Content = panel;
        }

        public string DisplayName => "Windows 8.1 Start Screen";
        public object CreateView() => this;

        private Border Tile(string text)
        {
            return new Border
            {
                Width = 160,
                Height = 100,
                Margin = new Thickness(8),
                CornerRadius = new CornerRadius(12),
                Background = new SolidColorBrush(Color.FromArgb(220, 0, 120, 215)),
                Child = new TextBlock
                {
                    Text = text,
                    Foreground = Brushes.White,
                    FontSize = 18,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(12)
                }
            };
        }
    }
}
