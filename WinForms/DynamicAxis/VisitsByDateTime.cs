using System;
using LiveCharts;
using LiveCharts.Configurations;

namespace Geared.Winforms.DynamicAxis
{
    public class VisitsByDateTime
    {
        static VisitsByDateTime()
        {
            //lets configure the type globally
            //notice since this block is inside a 
            //static constructor, it only runs once
            //mappers should ideally only be set once.

            var mapper = Mappers.Xy<VisitsByDateTime>()
                .X(item => item.DateTime.Ticks)
                .Y(item => (double) item.Total);

            Charting.For<VisitsByDateTime>(mapper);
        }

        public decimal Total { get; set; }
        public DateTime DateTime { get; set; }
    }
}