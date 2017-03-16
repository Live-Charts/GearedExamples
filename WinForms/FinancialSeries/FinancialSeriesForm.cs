using System;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace Geared.Winforms.FinancialSeries
{
    public partial class FinancialSeriesForm : Form
    {
        private FinancialSeriesViewModel _vm = new FinancialSeriesViewModel();

        public FinancialSeriesForm()
        {
            InitializeComponent();

            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Zoom = ZoomingOptions.None;
            cartesianChart1.Pan = PanningOptions.X;

            //alternatively you can use GCandleSeries
            cartesianChart1.Series.Add(new GOhlcSeries
            {
                Values = _vm.Values,
                StrokeThickness = 3,
                DecreaseBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(203,105,105)),
                IncreaseBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(71,156,74))
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = _vm.Labels
            });

            cartesianChart1.DataTooltip = new DefaultTooltip
            {
                ShowSeries = false
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _vm.SetLast45();
            cartesianChart1.AxisX[0].MinValue = _vm.MinAxisLimit;
            cartesianChart1.AxisX[0].MaxValue = _vm.MaxAxisLimit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _vm.SetLast90();
            cartesianChart1.AxisX[0].MinValue = _vm.MinAxisLimit;
            cartesianChart1.AxisX[0].MaxValue = _vm.MaxAxisLimit;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _vm.SetLast180();
            cartesianChart1.AxisX[0].MinValue = _vm.MinAxisLimit;
            cartesianChart1.AxisX[0].MaxValue = _vm.MaxAxisLimit;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _vm.SetLast365();
            cartesianChart1.AxisX[0].MinValue = _vm.MinAxisLimit;
            cartesianChart1.AxisX[0].MaxValue = _vm.MaxAxisLimit;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _vm.SetLast5Years();
            cartesianChart1.AxisX[0].MinValue = _vm.MinAxisLimit;
            cartesianChart1.AxisX[0].MaxValue = _vm.MaxAxisLimit;
        }
    }
}
