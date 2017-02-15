using System;
using System.Collections.Generic;
using LiveCharts.Defaults;
using LiveCharts.Geared;

namespace WinForms.ScrollableChart
{
    public class ScrollableViewModel
    {
        public ScrollableViewModel()
        {
            var now = DateTime.Now;
            var trend = -30000d;
            var l = new List<DateTimePoint>();
            var r = new Random();

            for (var i = 0; i < 50000; i++)
            {
                now = now.AddHours(1);
                l.Add(new DateTimePoint(now.AddDays(i), trend));

                if (r.NextDouble() > 0.4)
                {
                    trend += r.NextDouble()*10;
                }
                else
                {
                    trend -= r.NextDouble()*10;
                }
            }

            Formatter = x => new DateTime((long) x).ToString("yyyy");

            Values = l.AsGearedValues().WithQuality(Quality.High);

            From = DateTime.Now.AddHours(10000).Ticks;
            To = DateTime.Now.AddHours(90000).Ticks;
        }

        public object Mapper { get; set; }
        public GearedValues<DateTimePoint> Values { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
