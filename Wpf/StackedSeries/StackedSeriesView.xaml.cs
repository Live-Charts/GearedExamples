using System;
using System.Windows.Controls;

namespace Geared.Wpf.StackedSeries
{
    /// <summary>
    /// Interaction logic for StackedSeriesView.xaml
    /// </summary>
    public partial class StackedSeriesView : UserControl, IDisposable
    {
        public StackedSeriesView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (StackedSeriesViewModel) DataContext;
            vm.Values1.Dispose();
        }
    }
}
