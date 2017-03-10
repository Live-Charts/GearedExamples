using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfGeared.FianancialSeries
{
    public static class DataProvider
    {
        public static IEnumerable<DataProviderPoint> Get
        {
            get
            {
                //this object mocks a data provider


                //in this case we get our data in a simple array
                //with the following structure
                //[open, high, low, close]
                //i.e.
                //[10, 11, 5, 7]

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