using System;
using LiveCharts;
using LiveCharts.Configurations;

namespace Geared.Winforms.StackedSeries
{
    public class LecturePoint
    {
        public LecturePoint()
        {

        }

        public LecturePoint(TimeSpan timeSpan, double value)
        {
            TimeSpan = timeSpan;
            Value = value;
        }

        public TimeSpan TimeSpan { get; set; }
        public double Value { get; set; }

        public static void RegisterInLiveCharts()
        {
            //here we are teaching LiveCharts how to plot LecturePoint class
            //you can find more information here:
            //https://lvcharts.net/App/examples/v1/wpf/Types%20and%20Configuration

            var mapper = Mappers.Xy<LecturePoint>()
                .X(point => point.TimeSpan.Ticks)
                .Y(point => point.Value);

            Charting.For<LecturePoint>(mapper);
        }
    }
}
