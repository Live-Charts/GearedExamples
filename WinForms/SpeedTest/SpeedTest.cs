using System.Windows.Forms;
using LiveCharts.Geared;

namespace WinForms.SpeedTest
{
    public partial class SpeedTest : Form
    {
        private SpeedTestVm _viewModel = new SpeedTestVm();

        public SpeedTest()
        {
            InitializeComponent();

            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values
            });
            cartesianChart1.DisableAnimations = true;
        }

        private void StartOnClick(object sender, System.EventArgs e)
        {
            _viewModel.Read();
        }

        private void StopOnClik(object sender, System.EventArgs e)
        {
            _viewModel.Stop();
        }

        private void ClearOnClick(object sender, System.EventArgs e)
        {
            _viewModel.Values.Clear();
        }
    }
}
