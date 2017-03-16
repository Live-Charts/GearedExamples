using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Events;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using Binding = System.Windows.Data.Binding;

namespace Geared.Winforms.ScrollableChart
{
    public partial class ScrollableExample : Form
    {
        private ScrollableViewModel _viewModel = new ScrollableViewModel();
        
        public ScrollableExample()
        {
            InitializeComponent();

            //Cartesian Chart
            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Hoverable = false;

            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                StrokeThickness = 0,
                AreaLimit = 0,
                Fill = new SolidColorBrush(Color.FromRgb(33, 147, 240)),
                PointGeometry = null
            });
            var ax = new Axis
            {
                LabelFormatter = _viewModel.Formatter,
                Separator = new Separator {IsEnabled = false}
            };
            ax.RangeChanged += Axis_OnRangeChanged;
            cartesianChart1.AxisX.Add(ax);

            //Scroller Chart
            scrollerChart.DisableAnimations = true;
            scrollerChart.ScrollMode = ScrollMode.X;
            scrollerChart.ScrollBarFill = new SolidColorBrush(Color.FromArgb(37, 48, 48, 48));
            scrollerChart.DataTooltip = null;
            scrollerChart.Hoverable = false;
            scrollerChart.DataTooltip = null;
            scrollerChart.AxisX.Add(new Axis 
            {
                LabelFormatter = x => new DateTime((long) x).ToString("yyyy"),
                Separator = new Separator {IsEnabled = false},
                IsMerged = true,
                Foreground = new SolidColorBrush(Color.FromArgb(152, 0, 0, 0)),
                FontSize = 22,
                FontWeight = FontWeights.UltraBold
            });
            scrollerChart.AxisY.Add(new Axis {Separator = new Separator {IsEnabled = true}, ShowLabels = false});
            scrollerChart.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                Fill = Brushes.Silver,
                StrokeThickness = 0,
                PointGeometry = null,
                AreaLimit = 0
            });

            //lets bind the charts

            //the assistant synchronizes both charts
            //here he are setting the initial range
            var assistant = new BindingAssistant
            {
                From = _viewModel.From,
                To = _viewModel.To
            };

            cartesianChart1.AxisX[0].SetBinding(Axis.MinValueProperty, 
                new Binding {Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay});
            cartesianChart1.AxisX[0].SetBinding(Axis.MaxValueProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });

            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalFromProperty,
                new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay});
            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalToProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs eventargs)
        {
            var currentRange = eventargs.Range;

            if (currentRange < TimeSpan.TicksPerDay * 2)
            {
                _viewModel.Formatter = x => new DateTime((long)x).ToString("t");
                return;
            }

            if (currentRange < TimeSpan.TicksPerDay * 60)
            {
                _viewModel.Formatter = x => new DateTime((long)x).ToString("dd MMM yy");
                return;
            }

            if (currentRange < TimeSpan.TicksPerDay * 540)
            {
                _viewModel.Formatter = x => new DateTime((long)x).ToString("MMM yy");
                return;
            }

            _viewModel.Formatter = x => new DateTime((long)x).ToString("yyyy");
        }
    }
}
