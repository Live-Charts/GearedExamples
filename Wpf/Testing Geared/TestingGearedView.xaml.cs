using System;
using System.Windows;

namespace Geared.Wpf.Testing_Geared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TestingGearedView: IDisposable
    {
        private bool _noF;
        private TestingGearedViewModel Vm { get { return (TestingGearedViewModel) DataContext; } }

        public TestingGearedView()
        {
            InitializeComponent();
            Vm.Go();
        }

        private void GoOnClick(object sender, RoutedEventArgs e)
        {
            Vm.Go();
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

        public void Dispose()
        {
            var vm = (TestingGearedViewModel) DataContext;
            foreach (var seriesView in vm.SeriesCollection)
            {
                ((IDisposable) seriesView.Values).Dispose();
            }
        }
    }
}
