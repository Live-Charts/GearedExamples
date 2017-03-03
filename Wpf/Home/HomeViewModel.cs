using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using Wpf.Home;
using WpfGeared.DynamicAxisUnit;
using WpfGeared.Histogram;
using WpfGeared.Intro;
using WpfGeared.MultipleSeriesTest;
using WpfGeared.SpeedTest;
using ScrollableView = WpfGeared.Scrollable.ScrollableView;
using TestingGearedView = WpfGeared.Testing_Geared.TestingGearedView;

namespace WpfGeared.Home
{
    public class HomeViewModel: INotifyPropertyChanged
    {
        private UserControl _content;
        private bool _isMenuOpen;

        public HomeViewModel()
        {
            IsMenuOpen = true;
            Samples = new ObservableCollection<SampleVm>
            {
                new SampleVm
                {
                    Title = "Intro",
                    Content = typeof(IntroView)
                },
                new SampleVm
                {
                    Title = "Testing Geared",
                    Content = typeof(TestingGearedView)
                },
                new SampleVm
                {
                    Title = "Multi-thread speed Test",
                    Content = typeof(SpeedTestView)
                },
                new SampleVm
                {
                    Title = "Multiple Series",
                    Content = typeof(MultipleSeriesView)
                },
                new SampleVm
                {
                    Title = "Scrollable",
                    Content = typeof(ScrollableView)
                },
                new SampleVm
                {
                    Title = "Histogram",
                    Content = typeof(HistogramView)
                },
                new SampleVm
                {
                    Title = "Dynamic Axis",
                    Content = typeof(DynamicAxisUnitView)
                }
            };

            Content = (UserControl) Activator.CreateInstance( Samples[0].Content);
        }

        public ObservableCollection<SampleVm> Samples { get; set; }
        public UserControl Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }
        public bool IsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                OnPropertyChanged("IsMenuOpen");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
