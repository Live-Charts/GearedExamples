using System;
using LiveCharts.Geared;

namespace WinForms.DynamicAxis
{
    public class DynamicAxisUnitVm
    {
        #region Constructors

        public DynamicAxisUnitVm()
        {
            Values = Repository.VisitsByMinute.AsGearedValues();
            SetMinutesView();
        }

        #endregion


        #region Properties

        public GearedValues<VisitsByDateTime> Values { get; set; }
        public double AxisUnit { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public Func<double, string> Formatter { get; set; }

        #endregion


        #region Methods

        public void SetMinutesView()
        {
            Values = Repository.VisitsByMinute.AsGearedValues();
            Formatter = val => new DateTime((long) val).ToString("mm:ss");
            AxisUnit = TimeSpan.TicksPerMinute;
            Min = (DateTime.Now - TimeSpan.FromMinutes(30)).Ticks;
            Max = DateTime.Now.Ticks;
        }

        public void SetHourView()
        {
            Values = Repository.VisitsByHour.AsGearedValues();
            Formatter = val => new DateTime((long)val).ToString("hh:mm");
            AxisUnit = TimeSpan.TicksPerHour;
            Min = (DateTime.Now - TimeSpan.FromHours(24)).Ticks;
            Max = DateTime.Today.Ticks;
        }

        public void SetDayView()
        {
            Values = Repository.VisitsByDay.AsGearedValues();
            Formatter = val => new DateTime((long)val).ToString("dd MMMM");
            AxisUnit = TimeSpan.TicksPerDay;
            Min = (DateTime.Today - TimeSpan.FromDays(5)).Ticks;
            Max = DateTime.Today.Ticks;
        }

        #endregion

    }
}
