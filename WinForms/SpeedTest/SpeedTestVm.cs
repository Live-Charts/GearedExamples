using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Geared;

namespace WinForms.SpeedTest
{
    public class SpeedTestVm
    {
        private double _trend;

        public SpeedTestVm()
        {
            Values = new GearedValues<double>().WithQuality(Quality.High);
        }

        public bool IsReading { get; set; }
        public GearedValues<double> Values { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }

        public void Stop()
        {
            IsReading = false;
        }

        public void Clear()
        {
            Values.Clear();
        }

        public void Read()
        {
            if (IsReading) return;

            //lets keep in memory only the last 20000 records,
            //to keep everything running faster
            const int keepRecords = 20000;
            IsReading = true;

            Action readFromTread = () =>
            {
                while (IsReading)
                {
                    Thread.Sleep(1);
                    var r = new Random();
                    _trend += (r.NextDouble() < 0.5 ? 1 : -1) * r.Next(0, 10)*.001;
                    //when multi threading avoid indexed calls like -> Values[0] 
                    //instead enumerate the collection
                    //ChartValues/GearedValues returns a thread safe copy once you enumerate it.
                    //TIPS: use foreach instead of for
                    //LINQ methods also enumerate the collections
                    var first = Values.DefaultIfEmpty(0).FirstOrDefault();
                    if (Values.Count > keepRecords - 1) Values.Remove(first);
                    if (Values.Count < keepRecords) Values.Add(_trend);
                    IsHot = _trend > 0;
                    Count = Values.Count;
                    CurrentLecture = _trend;
                }
            };

            //2 different tasks adding a value every ms
            //add as many tasks as you want to test this feature
            Task.Factory.StartNew(readFromTread);
            Task.Factory.StartNew(readFromTread);
            Task.Factory.StartNew(readFromTread);
            //Task.Factory.StartNew(readFromTread);
            //Task.Factory.StartNew(readFromTread);
            //Task.Factory.StartNew(readFromTread);
            //Task.Factory.StartNew(readFromTread);
            //Task.Factory.StartNew(readFromTread);
        }
    }
}
