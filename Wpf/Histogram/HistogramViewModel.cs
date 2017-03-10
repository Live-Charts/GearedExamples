using LiveCharts.Geared;

namespace WpfGeared.Histogram
{
    public class HistogramViewModel
    {
        public HistogramViewModel()
        {
            Values1 = DataProvider.GetNormalDistribution(10, 50, 100).AsGearedValues();
            Values2 = DataProvider.GetNormalDistribution(15, 55, 250).AsGearedValues();
            Values3 = DataProvider.GetNormalDistribution(8, 45, 60).AsGearedValues();
        }

        public GearedValues<double> Values1 { get; set; }
        public GearedValues<double> Values2 { get; set; }
        public GearedValues<double> Values3 { get; set; }
    }
}
