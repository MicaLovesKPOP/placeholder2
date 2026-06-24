using WindBar.Core;

namespace WindBar.App.Views
{
    public partial class StartMenuClassic : System.Windows.Controls.UserControl, IStartMenuProvider
    {
        public StartMenuClassic()
        {
            InitializeComponent();
        }

        public string DisplayName => "Classic Start";

        public object CreateView()
        {
            return this;
        }
    }
}
