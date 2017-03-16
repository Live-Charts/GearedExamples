using System;
using System.Collections.Generic;
using System.Linq;

namespace Geared.Winforms.FinancialSeries
{
    public static class DataProvider
    {
        public static IEnumerable<DataProviderPoint> Get
        {
            get
            {
                var trend = 0d;
                var timeStamp = DateTime.Now.AddDays(-350*10);
                var r = new Random();

                for (var i = 0; i < 365*10; i++) //10 years of data approx
                {
                    //we are faking some random points....
                    var mockedData = new double[]
                        {r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100), r.Next(-100, 100)};

                    yield return new DataProviderPoint
                    {
                        Open = trend,
                        Close = trend + mockedData.Last(),
                        High = trend + mockedData.Max(),
                        Low = trend + mockedData.Min(),
                        DateTime = timeStamp.AddDays(i)
                    };

                    trend += mockedData.Last();
                }
            }
        }
    }
}