using System.Windows;
using System.Windows.Controls;

namespace Geared.Wpf.Histogram
{
    /// <summary>
    /// Interaction logic for HistogramView.xaml
    /// </summary>
    public partial class HistogramView : UserControl
    {
        public HistogramView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Control.DataContext = new HistogramViewModel();
        }
    }
}
