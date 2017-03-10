using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;

namespace WpfGeared.Scatter
{
    /// <summary>
    /// Interaction logic for ScatterView.xaml
    /// </summary>
    public partial class ScatterView : UserControl
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
    }
}
