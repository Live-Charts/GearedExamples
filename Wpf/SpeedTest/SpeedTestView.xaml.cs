using System;
using System.Windows.Controls;

namespace Geared.Wpf.SpeedTest
{
    /// <summary>
    /// Interaction logic for SpeedTestView.xaml
    /// </summary>
    public partial class SpeedTestView : UserControl, IDisposable
    {
        public SpeedTestView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (SpeedTestVm) DataContext;
            vm.Values.Dispose();
        }
    }
}
