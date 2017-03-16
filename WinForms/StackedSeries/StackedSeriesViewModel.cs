using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts.Geared;

namespace Geared.Winforms.StackedSeries
{
    public class StackedSeriesViewModel
    {
        private bool _isReading;
        private DateTime _timeStamp;
        private double _k;
        private bool _refreshAxis;

        public StackedSeriesViewModel()
        {
            LecturePoint.RegisterInLiveCharts();

            Values1 = new GearedValues<LecturePoint>().WithQuality(Quality.High);
            Values2 = new GearedValues<LecturePoint>().WithQuality(Quality.High);
            Values3 = new GearedValues<LecturePoint>().WithQuality(Quality.High);

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
        public double Step { get; set; }
        public double From { get; set; }
        public double To { get; set; }

        public void Read(BindingAssistant assistant)
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
                        assistant.To = lastPoint.Ticks;
                        assistant.From = lastPoint.Ticks - TimeSpan.FromSeconds(10).Ticks;
                    }
                }
            });
        }

        public void PictureLast10(BindingAssistant assistant)
        {
            var lastPoint = Values3.DefaultIfEmpty(new LecturePoint()).Last().TimeSpan;
            assistant.To = lastPoint.Ticks;
            assistant.From = lastPoint.Ticks - TimeSpan.FromSeconds(10).Ticks;
            _isReading = false;
        }

        public void StayInLast10()
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
    }
}

