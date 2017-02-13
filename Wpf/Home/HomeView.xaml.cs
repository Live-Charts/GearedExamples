using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Wpf.Home;

namespace WpfGeared.Home
{
    public partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm) ((Border) sender).DataContext;
            var hvm = (HomeViewModel) DataContext;
            hvm.Content = sample.Content;
            hvm.IsMenuOpen = false;
        }
    }
}
