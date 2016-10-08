using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;

namespace Wpf
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        private double _points;
        private SeriesCollection _seriesCollection;

        public MainWindowVm()
        {
            _points = 100000d;
            Quality = Quality.Medium;
        }

        public double Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged();
            }
        }

        public Quality Quality { get; set; }

        public void Go()
        {
            Points = Math.Truncate(Points);

            var ar = new double[(int) Points+1];

            var r = new Random();
            var trend = 0d;

            for (var i = 0; i < Points; i++)
            {
                ar[i] = trend;

                if (r.NextDouble() > 0.5)
                {
                    trend += r.NextDouble()*10;
                }
                else
                {
                    trend -= r.NextDouble()*10;
                }
            }

            var series = new GLineSeries
            {
                Values = ar.AsGearedValues().WithQuality(Quality)
            };

            SeriesCollection = new SeriesCollection
            {
                series
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SeriesVm
    {
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
