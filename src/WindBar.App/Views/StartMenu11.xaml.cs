using System.Windows.Controls;
using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenu11 : UserControl, IStartMenuProvider
    {
        private readonly AppScanner _scanner = new AppScanner();

        public StartMenu11()
        {
            Content = CreateView();
        }

        public string DisplayName => "Windows 11 Start";

        public object CreateView()
        {
            return new StartSurface("Windows 11 Start", _scanner.ScanSmartDefaults());
        }
    }
}
