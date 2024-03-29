﻿using MahApps.Metro.Controls;
using System.Windows;
using WindowsStoreClone.Pages;
using WindowsStoreClone.UserControls;

namespace WindowsStoreClone
{

    public partial class MainWindow : MetroWindow
    {
        private Main MainWindowContentPage;
        private TopAppsWrapped MyTopAppsWrappedPage;
        private DownloadsAndUpdates DownloadsAndUpdatesPage;
        //private MetroWindow accentThemeTestWindow;

        public MainWindow()
        {
            InitializeComponent();
            MainWindowContentPage = new Main();
            MainWindowContentPage.TopAppButtonClicked += MainWindowContentPage_TopAppButtonClicked;
            MainWindowContentPage.AppClicked += MainWindowContentPage_AppClicked;
            MainWindowContentPage.DownloadsAndUpdatesClicked += MainWindowContentPage_DownloadsAndUpdatesClicked;

            MyTopAppsWrappedPage = new TopAppsWrapped();
            MyTopAppsWrappedPage.AnAppClicked += MainWindowContentPage_AppClicked;
            MyTopAppsWrappedPage.BackButtonClicked += BackButtonClicked;

            DownloadsAndUpdatesPage = new DownloadsAndUpdates();
            DownloadsAndUpdatesPage.BackButtonClicked += BackButtonClicked;
        }

        private void MainWindowContentPage_DownloadsAndUpdatesClicked()
        {
            MainWindowFrame.Content = DownloadsAndUpdatesPage;
        }

        private void MainWindowContentPage_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MyTopAppsWrappedPage;
        }

        private void MainWindowContentPage_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppDetails myAppDetails = new AppDetails(sender);
            myAppDetails.AppClicked += MainWindowContentPage_AppClicked;
            myAppDetails.BackButtonClicked += BackButtonClicked;
            MainWindowFrame.Content = myAppDetails;
        }
        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (MainWindowFrame.NavigationService.CanGoBack)
                MainWindowFrame.NavigationService.GoBack();
        }
        private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MainWindowContentPage;
        }
    }
}
