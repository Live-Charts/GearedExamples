using System;
using LiveCharts;
using LiveCharts.Configurations;

namespace Geared.Winforms.FinancialSeries
{
    public class DataProviderPoint
    {
        static DataProviderPoint()
        {
            //lets configure our charts to plot DataProviderPoint
            //a global mapper should only be set once.
            //thus we are using the static constructor of DataProviderPoint

            //lets define a mapper
            var mapper = Mappers.Financial<DataProviderPoint>()
                .Open(x => x.Open)
                .High(x => x.High)
                .Low(x => x.Low)
                .Close(x => x.Close);

            //lets save the mapper globally, for more info please see:
            //https://lvcharts.net/App/examples/v1/wpf/Types%20and%20Configuration
            Charting.For<DataProviderPoint>(mapper);
        }

        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public DateTime DateTime { get; set; }
    }
}
