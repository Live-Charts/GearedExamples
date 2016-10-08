using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Navigation;

namespace Wpf
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
    }
}
