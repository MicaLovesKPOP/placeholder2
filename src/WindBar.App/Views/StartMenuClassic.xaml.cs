using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenuClassic : UserControl, IStartMenuProvider
    {
        public StartMenuClassic()
        {
            Content = new TextBlock
            {
                Text = "Classic Start, re-imagined for Windows 11",
                Foreground = Brushes.White,
                FontSize = 24,
                Margin = new Thickness(24)
            };
        }

        public string DisplayName => "Classic Start";
        public object CreateView() => this;
    }
}
