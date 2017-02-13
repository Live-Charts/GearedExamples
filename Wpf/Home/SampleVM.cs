using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf.Home
{
    public class SampleVm
    {
        private static int _idCount;

        public SampleVm()
        {
            Id = _idCount++;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public ImageSource ImageSource { get; set; }
        public string Text { get; set; }
        public UserControl Content { get; set; }
    }
}

namespace Wpf.Home.Wpf.Home
{
    public class SampleVm
    {
        private static int _idCount;

        public SampleVm()
        {
            Id = _idCount++;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public UserControl Content { get; set; }
    }
}
