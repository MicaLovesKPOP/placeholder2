using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenu11 : System.Windows.Controls.UserControl, IStartMenuProvider
    {
        public StartMenu11()
        {
            InitializeComponent();
        }

        public string DisplayName => "Windows 11 Start";

        public object CreateView()
        {
            return this;
        }
    }
}
