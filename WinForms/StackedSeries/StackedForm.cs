using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using Binding = System.Windows.Data.Binding;
using Panel = System.Windows.Controls.Panel;

namespace Geared.Winforms.StackedSeries
{
    public partial class StackedForm : Form
    {
        private StackedSeriesViewModel _vm = new StackedSeriesViewModel();
        private BindingAssistant _assistant;

        public StackedForm()
        {
            InitializeComponent();

            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Pan = PanningOptions.X;
            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _vm.Values1,
                StrokeThickness = 0,
                AreaLimit = 0,
                PointGeometry = null
            });
            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _vm.Values2,
                StrokeThickness = 0,
                AreaLimit = 0,
                PointGeometry = null
            });
            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _vm.Values3,
                StrokeThickness = 0,
                AreaLimit = 0,
                PointGeometry = null
            });

            //z index order
            Panel.SetZIndex((FrameworkElement) cartesianChart1.Series[0], 3);
            Panel.SetZIndex((FrameworkElement)cartesianChart1.Series[1], 2);
            Panel.SetZIndex((FrameworkElement)cartesianChart1.Series[2], 1);

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = _vm.XFormatter,
                Separator = new Separator
                {
                    Step = _vm.Step,
                    IsEnabled = false
                }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                MinValue = -1,
                MaxValue = 1,
                LabelFormatter = _vm.YFormatter,
                Separator = new Separator
                {
                    Stroke = new SolidColorBrush(Color.FromRgb(235,235,235))
                }
            });

            scrollerchart.DisableAnimations = true;
            scrollerchart.ScrollMode = ScrollMode.X;
            scrollerchart.ScrollBarFill = new SolidColorBrush(Color.FromArgb(25, 30, 30, 30));
            scrollerchart.DataTooltip = null;
            scrollerchart.Hoverable = false;
            scrollerchart.Series.Add(new GLineSeries
            {
                Values = _vm.Values3,
                Fill = new SolidColorBrush(Color.FromRgb(215,67,21)),
                AreaLimit = 0,
                PointGeometry = null
            });
            scrollerchart.AxisX.Add(new Axis
            {
                ShowLabels = false,
                Separator = new Separator
                {
                    IsEnabled = false
                }
            });
            scrollerchart.AxisY.Add(new Axis
            {
                MinValue = -1,
                MaxValue = 1,
                Separator = new Separator
                {
                    Stroke = new SolidColorBrush(Color.FromRgb(235, 235, 235))
                }
            });

            //lets bind the charts

            //the assistant synchronizes both charts
            //here he are setting the initial range
            _assistant = new BindingAssistant
            {
                From = _vm.From,
                To = _vm.To
            };

            cartesianChart1.AxisX[0].SetBinding(Axis.MinValueProperty,
                new System.Windows.Data.Binding { Path = new PropertyPath("From"), Source = _assistant, Mode = BindingMode.TwoWay });
            cartesianChart1.AxisX[0].SetBinding(Axis.MaxValueProperty,
                new System.Windows.Data.Binding { Path = new PropertyPath("To"), Source = _assistant, Mode = BindingMode.TwoWay });

            scrollerchart.Base.SetBinding(CartesianChart.ScrollHorizontalFromProperty,
                new System.Windows.Data.Binding { Path = new PropertyPath("From"), Source = _assistant, Mode = BindingMode.TwoWay });
            scrollerchart.Base.SetBinding(CartesianChart.ScrollHorizontalToProperty,
                new Binding { Path = new PropertyPath("To"), Source = _assistant, Mode = BindingMode.TwoWay });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _vm.Read(_assistant);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _vm.PictureLast10(_assistant);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _vm.StayInLast10();
        }
    }
}
