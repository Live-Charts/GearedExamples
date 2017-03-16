using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts.Geared;

namespace Geared.Wpf.StackedSeries
{
    public class StackedSeriesViewModel : INotifyPropertyChanged
    {
        private bool _isReading;
        private readonly Random _seed = new Random();
        private DateTime _timeStamp;
        private double _k;
        private double _from;
        private double _to;
        private bool _refreshAxis;

        public StackedSeriesViewModel()
        {
            LecturePoint.RegisterInLiveCharts();

            Values1 = new GearedValues<LecturePoint>().WithQuality(Quality.High);
            Values2 = new GearedValues<LecturePoint>().WithQuality(Quality.High);
            Values3 = new GearedValues<LecturePoint>().WithQuality(Quality.High);
            ReadCommand = new RelayCommand(Read);
            PictureLast10Command = new RelayCommand(PictureLast10);
            StayInLast10Command = new RelayCommand(StayInLast10);
            Step = TimeSpan.FromSeconds(5).Ticks;
            XFormatter = val =>
            {
                var ts = TimeSpan.FromTicks((long) val);

                return string.Format("{0}' {1}''",ts.Minutes,
                    ts.Seconds);
            };
            YFormatter = val => val.ToString("N2");
            From = double.NaN;
            To = double.NaN;
        }

        public GearedValues<LecturePoint> Values1 { get; set; }
        public GearedValues<LecturePoint> Values2 { get; set; }
        public GearedValues<LecturePoint> Values3 { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand PictureLast10Command { get; set; }
        public ICommand StayInLast10Command { get; set; }
        public double Step { get; set; }

        public double From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged("From");
            }
        }

        public double To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged("To");
            }
        }

        private void Read()
        {
            _isReading = !_isReading;

            Task.Factory.StartNew(() =>
            {
                _timeStamp = DateTime.Now;

                Values1.Clear();
                Values2.Clear();
                Values3.Clear();

                while (_isReading)
                {
                    Thread.Sleep(100);

                    var newItems = GetNext(1);

                    Values1.AddRange(newItems.Select(x => x.Series1Lecture));
                    Values2.AddRange(newItems.Select(x => x.Series2Lecture));
                    Values3.AddRange(newItems.Select(x => x.Series3Lecture));

                    if (_refreshAxis)
                    {
                        var lastPoint = Values3.DefaultIfEmpty(new LecturePoint()).Last().TimeSpan;
                        To = lastPoint.Ticks;
                        From = lastPoint.Ticks - TimeSpan.FromSeconds(10).Ticks;
                    }
                }
            });
        }

        private void PictureLast10()
        {
            var lastPoint = Values3.DefaultIfEmpty(new LecturePoint()).Last().TimeSpan;
            To = lastPoint.Ticks;
            From = lastPoint.Ticks - TimeSpan.FromSeconds(10).Ticks;
            _isReading = false;
        }

        private void StayInLast10()
        {
            _refreshAxis = !_refreshAxis;
        }

        private DetailedLecture[] GetNext(int count)
        {
            var result = new DetailedLecture[count];

            for (var i = 0; i < count; i++)
            {
                #region Value Generator, Ignore this
                _k += .1;
                var f = Math.Sin(_k);
                var c1 = f * .2;
                var c2 = f * .45;
                var c3 = f * .35;
                //.2 + . 45 + .65 = 1, this just forces the Sin function
                #endregion

                var time = DateTime.Now - _timeStamp;

                var lecture = new DetailedLecture
                {
                    Series1Lecture = new LecturePoint(time, c1),
                    Series2Lecture = new LecturePoint(time, c1 + c2),
                    Series3Lecture = new LecturePoint(time, c1 + c2 + c3)
                };

                result[i] = lecture;
            }
            return result;
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

