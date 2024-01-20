using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls.AppDetailisTabContent
{

    public partial class Overview : UserControl
    {
        public delegate void OnAppDetailsApplicked(AnApp sender, RoutedEventArgs e);
        public event OnAppDetailsApplicked AppClicked;
        public Overview()
        {
            InitializeComponent();
            AppsViewerInsideOwerviewTab.AppClicked += AppsViewerInsideOwerviewTab_AnAppClicked;
        }

        private void AppsViewerInsideOwerviewTab_AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }
    }
}
