using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.AxisX = new AxesCollection
            {
                new Axis {MinRange = 10, MaxRange = 100000}
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ar = new double[100000];
            var r = new Random();
            var trend = 0d;

            for (var i = 0; i < 100000; i++)
            {
                ar[i] = trend;
                if (r.NextDouble() < 0.5)
                {
                    trend += r.NextDouble()*10;
                }
                else
                {
                    trend -= r.NextDouble()*10;
                }
            }

            cartesianChart1.Series = new SeriesCollection
            {
                new GLineSeries
                {
                    Values = ar.AsGearedValues().WithQuality(Quality.High),
                    StrokeThickness = 1
                }
            };
        }
    }
}
