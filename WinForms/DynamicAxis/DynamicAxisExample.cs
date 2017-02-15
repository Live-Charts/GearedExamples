using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace WinForms.DynamicAxis
{
    public partial class DynamicAxisExample : Form
    {
        private DynamicAxisUnitVm _viewModel = new DynamicAxisUnitVm();

        public DynamicAxisExample()
        {
            InitializeComponent();

            cartesianChart1.Zoom = ZoomingOptions.None;
            cartesianChart1.Base.Pan = PanningOptions.X; 
            cartesianChart1.Series.Add(new GColumnSeries
            {
                Values = _viewModel.Values
            });
            cartesianChart1.AxisX.Add(new Axis {LabelsRotation = -35});
            UpdateChart();
        }

        private void UpdateChart()
        {
            var x = cartesianChart1.AxisX[0];
            cartesianChart1.Series[0].Values = _viewModel.Values;
            x.Unit = _viewModel.AxisUnit;
            x.MinValue = _viewModel.Min;
            x.MaxValue = _viewModel.Max;
            x.LabelFormatter = _viewModel.Formatter;
            x.LabelsRotation = -35;
            x.Separator.Step = _viewModel.AxisUnit;
            x.Separator.IsEnabled = false;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            _viewModel.SetMinutesView();
            UpdateChart();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _viewModel.SetHourView();
            UpdateChart();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            _viewModel.SetDayView();
            UpdateChart();
        }
    }
}
