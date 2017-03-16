using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Geared.Geometries;

namespace Geared.Winforms.Scatter
{
    public partial class Scatterform : Form
    {
        private ScatterViewModel _vm = new ScatterViewModel();

        public Scatterform()
        {
            InitializeComponent();

            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Zoom = ZoomingOptions.Xy;
            cartesianChart1.Series.Add(new GScatterSeries
            {
                Values = _vm.Values1,
                GearedPointGeometry = GearedGeometries.Circle,
                MaxPointShapeDiameter = 8,
                Fill = new SolidColorBrush(Color.FromRgb(238,108,0))
            });
            cartesianChart1.Series.Add(new GScatterSeries
            {
                Values = _vm.Values2,
                GearedPointGeometry = new MarkerShape(),
                MaxPointShapeDiameter = 8,
                Fill = new SolidColorBrush(Color.FromRgb(40,53,146)),
                Stroke = new SolidColorBrush(Color.FromRgb(40, 53, 146)),
                StrokeThickness = 2
            });
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _vm.BuildRandomData();
            cartesianChart1.Series[0].Values = _vm.Values1;
            cartesianChart1.Series[1].Values = _vm.Values2;
        }
    }
}
