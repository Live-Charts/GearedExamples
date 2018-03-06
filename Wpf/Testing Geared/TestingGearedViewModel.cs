using System;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace Geared.Wpf.Testing_Geared
{
    public class TestingGearedViewModel : INotifyPropertyChanged
    {
        private double _points;
        private SeriesCollection _seriesCollection;
        private double _min;
        private double _max;

        public TestingGearedViewModel()
        {
            _points = 100000;
            Quality = Quality.Medium;
            Max = double.NaN;
            Min = double.NaN;
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

        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged();
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged();
            }
        }

        public void Go()
        {
            Points = Math.Truncate(Points);

            var ar = new double[(int) Points];

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

            var series = new GLineSeries()
            {
                Values = ar.AsGearedValues()
            };

            SeriesCollection = new SeriesCollection
            {
                series
            };

            //reset axis limits
            Max = double.NaN;
            Min = double.NaN;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
