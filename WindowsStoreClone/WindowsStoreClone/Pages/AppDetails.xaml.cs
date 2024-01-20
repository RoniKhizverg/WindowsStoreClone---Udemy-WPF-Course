using System.Windows;
using System;
using System.Windows.Controls;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone.Pages
{

    public partial class AppDetails : Page
    {
        public delegate void OnBackButtonClicked(Object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;

        public delegate void OnDetailsAnotherAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnDetailsAnotherAppClicked AppClicked;
        public AppDetails(AnApp anApp)
        {
            InitializeComponent();
            AppDetailsAndBackgroundUC.AppNameLabel.Content = anApp.AppName;
            AppDetailsAndBackgroundUC.AppImage.Source = anApp.AppImageSource;
            AppDetailsAndBackgroundUC.BackButtonClicked += AppDetailsAndBackgroundUC_BackButtonClicked;
            OverviewTabUC.AppClicked += OverViewTabUC_AppClicked;
        }
        private void AppDetailsAndBackgroundUC_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);
        }

        private void OverViewTabUC_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }
    }
}
