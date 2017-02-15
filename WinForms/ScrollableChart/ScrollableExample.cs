using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Events;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace WinForms.ScrollableChart
{
    public partial class ScrollableExample : Form
    {
        private ScrollableViewModel _viewModel = new ScrollableViewModel();
        private Axis _syncedAxis = new Axis();

        public ScrollableExample()
        {
            InitializeComponent();

            //Cartesian Chart
            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Base.Hoverable = false;

            cartesianChart1.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                StrokeThickness = 0,
                AreaLimit = 0,
                Fill = new SolidColorBrush(Color.FromRgb(33, 147, 240)),
                PointGeometry = null
            });
            _syncedAxis.LabelFormatter = _viewModel.Formatter;
            _syncedAxis.Separator = new Separator { IsEnabled = false };
            _syncedAxis.RangeChanged += Axis_OnRangeChanged;
            cartesianChart1.AxisX.Add(_syncedAxis);
            cartesianChart1.Update(true, true);

            //Scroller Chart
            scrollerChart.Base.ScrollMode = ScrollMode.X;
            scrollerChart.Base.ScrollBarFill = new SolidColorBrush(Color.FromArgb(37, 48, 48, 48));
            scrollerChart.DataTooltip = null;
            scrollerChart.Base.Hoverable = false;
            scrollerChart.DataTooltip = null;
            scrollerChart.AxisX.Add(new Axis
            {
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
        }

        private void UpdateScrollBar()
        {
            scrollerChart.Base.ScrollHorizontalFrom = _syncedAxis.ActualMinValue;
            scrollerChart.Base.ScrollHorizontalTo = _syncedAxis.ActualMaxValue;
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs eventargs)
        {
            UpdateScrollBar();

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

        private void ScrollableExample_Load(object sender, EventArgs e)
        {
            //UpdateScrollBar();
        }
    }
}
