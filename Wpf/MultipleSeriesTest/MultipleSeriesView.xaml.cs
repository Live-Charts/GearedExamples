using System;
using System.Windows.Controls;

namespace Geared.Wpf.MultipleSeriesTest
{
    /// <summary>
    /// Interaction logic for RecommendedSettingsView.xaml
    /// </summary>
    public partial class MultipleSeriesView : UserControl, IDisposable
    {
        public MultipleSeriesView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (MultipleSeriesVm) DataContext;
            for (var index = 0; index < vm.Series.Count; index++)
            {
                var series = vm.Series[index];
                var disposable = series.Values as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }

            vm.Series = null;
        }
    }
}
