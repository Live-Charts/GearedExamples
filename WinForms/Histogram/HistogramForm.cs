using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace Geared.Winforms.Histogram
{
    public partial class HistogramForm : Form
    {
        private HistogramViewModel _vm = new HistogramViewModel();

        public HistogramForm()
        {
            InitializeComponent();

            cartesianChart1.DisableAnimations = true;
            cartesianChart1.DataTooltip = null;

            cartesianChart1.Series.Add(new GColumnSeries
            {
               Values = _vm.Values1,
               Fill = new SolidColorBrush(Color.FromRgb(32,112,176)),
               ScalesXAt = 0,
               ColumnPadding = 0,
               MaxColumnWidth = 9999,
               SharesPosition = false
            });
            cartesianChart1.Series.Add(new GColumnSeries
            {
                Values = _vm.Values2,
                Fill = new SolidColorBrush(Color.FromRgb(198, 59, 49)),
                ScalesXAt = 1,
                ColumnPadding = 0,
                MaxColumnWidth = 9999,
                SharesPosition = false
            });
            cartesianChart1.Series.Add(new GColumnSeries
            {
                Values = _vm.Values3,
                Fill = new SolidColorBrush(Color.FromRgb(206, 157, 12)),
                ScalesXAt = 1,
                ColumnPadding = 0,
                MaxColumnWidth = 9999,
                SharesPosition = false
            });

            cartesianChart1.AxisX = new AxesCollection
            {
                new Axis {ShowLabels = false},
                new Axis {ShowLabels = false}
            };
        }
    }
}
