using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Geared;

namespace WpfGeared.SpeedTest
{
    public class SpeedTestVm : INotifyPropertyChanged
    {
        private double _trend;
        private double _count;
        private double _currentLecture;
        private bool _isHot;

        public SpeedTestVm()
        {
            Values = new GearedValues<double>().WithQuality(Quality.High);
            ReadCommand = new RelayCommand(Read);
            StopCommand = new RelayCommand(Stop);
            CleaCommand = new RelayCommand(Clear);
        }

        public bool IsReading { get; set; }
        public RelayCommand ReadCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        public RelayCommand CleaCommand { get; set; }
        public GearedValues<double> Values { get; set; }

        public double Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        public double CurrentLecture
        {
            get { return _currentLecture; }
            set
            {
                _currentLecture = value;
                OnPropertyChanged("CurrentLecture");
            }
        }

        public bool IsHot
        {
            get { return _isHot; }
            set
            {
                var changed = value != _isHot;
                _isHot = value;
                if (changed) OnPropertyChanged("IsHot");
            }
        }

        private void Stop()
        {
            IsReading = false;
        }

        private void Clear()
        {
            Values.Clear();
        }

        private void Read()
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
