using System;
using System.Windows.Forms;
using LiveCharts;
using WpfGeared.MultipleSeriesTest;

namespace WinForms.MultipleSeries
{
    public partial class MultipleSeriesExample : Form
    {
        private MultipleSeriesVm _viewModel = new MultipleSeriesVm();

        public MultipleSeriesExample()
        {
            InitializeComponent();

            cartesianChart1.Series = _viewModel.Series;
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.DataTooltip = null;
            cartesianChart1.AnimationsSpeed = TimeSpan.FromMilliseconds(150);
            cartesianChart1.Zoom = ZoomingOptions.Xy;
        }
    }
}
