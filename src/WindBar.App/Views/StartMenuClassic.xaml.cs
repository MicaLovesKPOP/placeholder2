using System.Windows.Controls;
using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenuClassic : UserControl, IStartMenuProvider
    {
        private readonly AppScanner _scanner = new AppScanner();

        public StartMenuClassic()
        {
            Content = CreateView();
        }

        public string DisplayName => "Classic Start";

        public object CreateView()
        {
            return new StartSurface("Classic Start", _scanner.ScanSmartDefaults());
        }
    }
}
