using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace Wpf.Testing_Geared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TestingGearedView
    {
        private bool _noF;

        public TestingGearedView()
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
            ((TestingGearedViewModel) DataContext).Go();
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
    }
}
