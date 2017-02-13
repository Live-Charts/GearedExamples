using System;
using System.ComponentModel;
using System.Linq;
using LiveCharts.Geared;

namespace WpfGeared.DynamicAxisUnit
{
    public class DynamicAxisUnitVm : INotifyPropertyChanged
    {
        #region Fields

        private Func<double, string> _formatter;
        private double _axisUnit;
        private double _min;
        private double _max;
        private GearedValues<VisitsByDateTime> _values;

        #endregion


        #region Constructors

        public DynamicAxisUnitVm()
        {
            Values = Repository.VisitsByMinute.AsGearedValues();
            ByMinute = new RelayCommand(SetMinutesView);
            ByHour = new RelayCommand(SetHourView);
            ByDay = new RelayCommand(SetDayView);
            SetMinutesView();
        }

        #endregion


        #region Properties

        public RelayCommand ByMinute { get; set; }
        public RelayCommand ByHour { get; set; }
        public RelayCommand ByDay { get; set; }

        public GearedValues<VisitsByDateTime> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged("Values");
            }
        }

        public double AxisUnit
        {
            get { return _axisUnit; }
            set
            {
                _axisUnit = value;
                OnPropertyChanged("AxisUnit");
            }
        }

        public double Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged("Min");
            }
        }

        public double Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged("Max");
            }
        }

        public Func<double, string> Formatter
        {
            get { return _formatter; }
            set
            {
                _formatter = value;
                OnPropertyChanged("Formatter");
            }
        }

        #endregion
        

        #region Private methods

        private void SetMinutesView()
        {
            Values = Repository.VisitsByMinute.AsGearedValues();
            Formatter = val => new DateTime((long) val).ToString("mm:ss");
            AxisUnit = TimeSpan.TicksPerMinute;
            Min = (DateTime.Now - TimeSpan.FromMinutes(30)).Ticks;
            Max = DateTime.Now.Ticks;
        }

        private void SetHourView()
        {
            Values = Repository.VisitsByHour.AsGearedValues();
            Formatter = val => new DateTime((long)val).ToString("hh:mm");
            AxisUnit = TimeSpan.TicksPerHour;
            Min = (DateTime.Now - TimeSpan.FromHours(24)).Ticks;
            Max = DateTime.Today.Ticks;
        }

        private void SetDayView()
        {
            Values = Repository.VisitsByDay.AsGearedValues();
            Formatter = val => new DateTime((long)val).ToString("dd MMMM");
            AxisUnit = TimeSpan.TicksPerDay;
            Min = (DateTime.Today - TimeSpan.FromDays(5)).Ticks;
            Max = DateTime.Today.Ticks;
        }

        #endregion


        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
