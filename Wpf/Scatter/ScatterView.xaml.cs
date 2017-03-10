using System.Windows;
using System.Windows.Controls;

namespace WpfGeared.Scatter
{
    /// <summary>
    /// Interaction logic for ScatterView.xaml
    /// </summary>
    public partial class ScatterView : UserControl
    {
        public ScatterView()
        {
            InitializeComponent();
        }

        private void GetDataOnClick(object sender, RoutedEventArgs e)
        {
            var vm = (ScatterViewModel) View.DataContext;
            vm.BuildRandomData();
        }
    }
}
