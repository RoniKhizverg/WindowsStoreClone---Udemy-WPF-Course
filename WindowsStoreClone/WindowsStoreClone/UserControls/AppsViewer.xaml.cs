using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowsStoreClone.UserControls
{

    public partial class AppsViewer : UserControl
    {
        List<AnApp> PresentedApps;
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;
        public AppsViewer()
        {
            InitializeComponent();
            PresentedApps = new List<AnApp>();
            AppsList.ItemsSource = PresentedApps;
            for (int i = 0; i < 9; i++)
            {
                AnApp curr = new AnApp();
                curr.AppClicked += Curr_AppClicked;
            PresentedApps.Add(curr);}
        }

        private void Curr_AppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }

        private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)PresentedApps.First().ActualWidth
                + 2 * (int)PresentedApps.First().Margin.Left;
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 1 * widthOfOneApp);
        }

        private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)PresentedApps.First().ActualWidth
              + 2 * (int)PresentedApps.First().Margin.Left;
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 1 * widthOfOneApp);
        }

        private void AppsScrollView_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice,e.Timestamp,e.Delta);
            eventArg.RoutedEvent = UIElement.MouseWheelEvent;
            eventArg.Source = sender;
            var parent =((Control)sender).Parent as UIElement;
            parent.RaiseEvent(eventArg);
        }
    }
}
