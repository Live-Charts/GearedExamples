using System;
using System.Windows;
using System.Windows.Controls;

namespace Geared.Wpf.Scatter
{
    /// <summary>
    /// Interaction logic for ScatterView.xaml
    /// </summary>
    public partial class ScatterView : UserControl, IDisposable
    {
        public ScatterView()
        {
            InitializeComponent();
        }

        private void GetDataOnClick(object sender, RoutedEventArgs e)
        {
            var vm = (ScatterViewModel) View.DataContext;
            vm.BuildRandomData();
        }

        public void Dispose()
        {
            var vm = (ScatterViewModel)View.DataContext;
            vm.Values1.Dispose();
            vm.Values2.Dispose();
        }
    }
}
