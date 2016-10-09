using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using Wpf.Scrolling;

namespace Wpf.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _noF;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void GoOnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowVm) DataContext).Go();
        }

        private void Animated_OnChecked(object sender, RoutedEventArgs e)
        {
            if (!_noF)
            {
                _noF = !_noF;
                return;
            }
            MessageBox.Show("Once you go animated, you could face a visual error with axis separators");
        }

        private void MoreOnClick(object sender, RoutedEventArgs e)
        {
            new ScrollingWindow().ShowDialog();
        }
    }
}
