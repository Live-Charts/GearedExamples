using System;
using System.Windows;
using System.Windows.Controls;

namespace Geared.Wpf.Histogram
{
    /// <summary>
    /// Interaction logic for HistogramView.xaml
    /// </summary>
    public partial class HistogramView : UserControl, IDisposable
    {
        public HistogramView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Control.DataContext = new HistogramViewModel();
        }

        public void Dispose()
        {
            var vm = (HistogramViewModel) Control.DataContext;
            vm.Values1.Dispose();
            vm.Values2.Dispose();
            vm.Values3.Dispose();
        }
    }
}
