﻿using System.Windows;
using System.Windows.Controls;

namespace WindowsStoreClone.UserControls
{
    public partial class HeaderRightButtons : UserControl
    {
        public delegate void OnDownloadButtonClick(object sender, RoutedEventArgs e);
        public event OnDownloadButtonClick HeaderRightButtonsDownloadButtonClick;

        public HeaderRightButtons()
        {
            InitializeComponent();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            SeachTextBox.Visibility = Visibility.Visible;
        }
        public void MouseDown_OutsideOfHeaderRightButtons()
        {
            if (!SeachTextBox.IsMouseOver)
            {
                SeachTextBox.Visibility = Visibility.Collapsed;
                SearchButton.Visibility = Visibility.Visible;
            }
        }
        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClick(sender, e);
        }
        private void DownloadsAndUpdatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClick(sender, e);
        }
    }
}
