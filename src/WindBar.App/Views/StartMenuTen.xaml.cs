using System.Windows.Controls;
using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenuTen : UserControl, IStartMenuProvider
    {
        private readonly AppScanner _scanner = new AppScanner();

        public StartMenuTen()
        {
            Content = CreateView();
        }

        public string DisplayName => "Modern Start";

        public object CreateView()
        {
            return new StartSurface("Modern Start", _scanner.ScanSmartDefaults());
        }
    }
}
