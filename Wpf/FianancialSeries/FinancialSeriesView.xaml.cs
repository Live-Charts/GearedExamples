using System;
using System.Windows.Controls;

namespace Geared.Wpf.FianancialSeries
{
    /// <summary>
    /// Interaction logic for FinancialSeriesView.xaml
    /// </summary>
    public partial class FinancialSeriesView : IDisposable
    {
        public FinancialSeriesView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (FinancialSeriesViewModel) DataContext;
            vm.Values.Dispose();
        }
    }
}
