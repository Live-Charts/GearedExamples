using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Wpf.Scrolling;
using Wpf.Testing_Geared;

namespace Wpf.Home
{
    public class HomeViewModel: INotifyPropertyChanged
    {
        private UserControl _content;

        public HomeViewModel()
        {
            Samples = new ObservableCollection<SampleVm>
            {
                new SampleVm
                { 
                    Title = "Testing Geared",
                    ImageSource = new BitmapImage(new Uri(@"/ExampleApp;component/Resources/TestingGeared.jpg", UriKind.Relative)),
                    Text = "Explains the capabilities and flexibility of the Geared package",
                    Content = new TestingGearedView()
                },
                new SampleVm
                {
                    Title = "Scrolling Chart",
                    ImageSource = new BitmapImage(new Uri(@"/ExampleApp;component/Resources/scrollablechart.jpg", UriKind.Relative)),
                    Text = "A Scrollable chart",
                    Content = new ScrollingView()
                }
            };
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
