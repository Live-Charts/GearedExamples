using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using LiveCharts.Geared;

namespace WpfGeared.Scatter
{
    public class ScatterViewModel : INotifyPropertyChanged
    {
        private GearedValues<CustomScatterPoint> _values1;
        private GearedValues<CustomScatterPoint> _values2;

        public ScatterViewModel()
        {
            BuildRandomData();
        }

        public GearedValues<CustomScatterPoint> Values1
        {
            get { return _values1; }
            set
            {
                _values1 = value;
                OnPropertyChanged("Values1");
            }
        }

        public GearedValues<CustomScatterPoint> Values2
        {
            get { return _values2; }
            set
            {
                _values2 = value;
                OnPropertyChanged("Values2");
            }
        }

        public void BuildRandomData()
        {
            var r = new Random();

            const int points = 3000;

            var v1 = new double[points][];
            var v2 = new double[points][];

            for (var i = 0; i < points; i++)
            {
                v1[i] = new [] {NormalDist(500, 300, r), NormalDist(500, 200, r)};
                v2[i] = new [] {NormalDist(400, 200, r), NormalDist(350, 280, r)};
            }

            Values1 = v1.Select(x => new CustomScatterPoint(x[0], x[1]))
                .AsGearedValues()
                .WithQuality(Quality.Medium);
            Values2 = v2.Select(x => new CustomScatterPoint(x[0], x[1]))
                .AsGearedValues()
                .WithQuality(Quality.Medium);
        }

        //Based on:
        //http://stackoverflow.com/questions/218060/random-gaussian-variables
        private static double NormalDist(double average, double variance, Random seed)
        {
            var u1 = 1.0 - seed.NextDouble();
            var u2 = 1.0 - seed.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *Math.Sin(2.0 * Math.PI * u2);
            return average + variance * randStdNormal;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
