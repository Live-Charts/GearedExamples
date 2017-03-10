using System;
using System.ComponentModel;
using System.Linq;
using LiveCharts.Geared;

namespace WpfGeared.FianancialSeries
{
    public class FinancialSeriesViewModel : INotifyPropertyChanged
    {
        private string[] _labels;
        private DataProviderPoint[] _data;
        private double _minAxisLimit;
        private double _maxAxisLimit;

        public FinancialSeriesViewModel()
        {
            _data = DataProvider.Get.ToArray();

            Last15DaysCommand = new RelayCommand(SetLast15Days);
            Last3MonthsCommand = new RelayCommand(SetLast3Months);
            LastYearCommand = new RelayCommand(SetLastYear);
            Last5YearsCommand = new RelayCommand(SetLast5Years);
            Last10YearsCommand = new RelayCommand(SetLast10Years);

            Values = _data.AsGearedValues();
            Labels = _data.Select(x => x.DateTime.ToString("dd MMM yy")).ToArray();

            SetLast15Days();
        }

        public RelayCommand Last15DaysCommand { get; set; }
        public RelayCommand Last3MonthsCommand { get; set; }
        public RelayCommand LastYearCommand { get; set; }
        public RelayCommand Last5YearsCommand { get; set; }
        public RelayCommand Last10YearsCommand { get; set; }
        
        public GearedValues<DataProviderPoint> Values { get; set; }

        public string[] Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged("Labels");
            }
        }

        public double MinAxisLimit
        {
            get { return _minAxisLimit; }
            set
            {
                _minAxisLimit = value;
                OnPropertyChanged("MinAxisLimit");
            }
        }

        public double MaxAxisLimit
        {
            get { return _maxAxisLimit; }
            set
            {
                _maxAxisLimit = value;
                OnPropertyChanged("MaxAxisLimit");
            }
        }

        private void SetLast15Days()
        {
            MinAxisLimit = _data.Length - 15;
            MaxAxisLimit = _data.Length;
        }

        private void SetLast3Months()
        {
            MinAxisLimit = _data.Length - 30.4*3;
            MaxAxisLimit = _data.Length;
        }

        private void SetLastYear()
        {
            MinAxisLimit = _data.Length - 365;
            MaxAxisLimit = _data.Length;
        }

        private void SetLast5Years()
        {
            MinAxisLimit = _data.Length - 365*5;
            MaxAxisLimit = _data.Length;
        }

        private void SetLast10Years()
        {
            //Auto scale min value according to data in chart
            MinAxisLimit = double.NaN;
            MaxAxisLimit = _data.Length;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
