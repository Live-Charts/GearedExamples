using System.Linq;
using LiveCharts.Geared;

namespace Geared.Winforms.FinancialSeries
{
    public class FinancialSeriesViewModel
    {
        private DataProviderPoint[] _data;

        public FinancialSeriesViewModel()
        {
            _data = DataProvider.Get.ToArray();

            Values = _data.AsGearedValues();
            Labels = _data.Select(x => x.DateTime.ToString("dd MMM yy")).ToArray();

            SetLast45();
        }
        
        public GearedValues<DataProviderPoint> Values { get; set; }
        public string[] Labels { get; set; }
        public double MinAxisLimit { get; set; }
        public double MaxAxisLimit { get; set; }

        public void SetLast45()
        {
            MinAxisLimit = _data.Length - 45;
            MaxAxisLimit = _data.Length;
        }

        public void SetLast90()
        {
            MinAxisLimit = _data.Length - 90;
            MaxAxisLimit = _data.Length;
        }

        public void SetLast180()
        {
            MinAxisLimit = _data.Length - 180;
            MaxAxisLimit = _data.Length;
        }

        public void SetLast365()
        {
            MinAxisLimit = _data.Length - 365;
            MaxAxisLimit = _data.Length;
        }

        public void SetLast5Years()
        {
            //Auto scale min value according to data in chart
            MinAxisLimit = _data.Length-365*5;
            MaxAxisLimit = _data.Length;
        }
    }
}
