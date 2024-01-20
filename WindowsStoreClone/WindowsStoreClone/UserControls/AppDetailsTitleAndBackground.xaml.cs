using System;
using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls
{

    public partial class AppDetailsTitleAndBackground : UserControl
    {
        public delegate void OnBackButtonClicked(Object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;
        public AppDetailsTitleAndBackground()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);
        }
    }
}
