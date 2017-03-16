using System;
using System.Collections.Generic;
using System.Linq;

namespace Geared.Wpf.DynamicAxisUnit
{
    public static class Repository
    {
        private static readonly List<VisitsByDateTime> Visits;

        static Repository()
        {
            Visits = new List<VisitsByDateTime>();
            var today = DateTime.Now - TimeSpan.FromMinutes(15000);
            var r = new Random();

            for (var i = 0; i < 15000; i++)
            {
                Visits.Add(new VisitsByDateTime
                {
                    DateTime = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, 0),
                    Total = r.Next(10, 100)
                });
                today = today + TimeSpan.FromMinutes(1);
            }
        }

        public static IEnumerable<VisitsByDateTime> VisitsByMinute
        {
            get
            {
                return Visits;
            }
        }

        public static IEnumerable<VisitsByDateTime> VisitsByHour
        {
            get
            {
                return Visits.GroupBy(x => string.Format("{0}*{1}*{2}*{3}",
                    x.DateTime.Year, x.DateTime.Month, x.DateTime.Day, x.DateTime.Hour))
                    .Select(x =>
                    {
                        var d = x.Key.Split('*').Select(int.Parse).ToArray();
                        return new VisitsByDateTime
                        {
                            DateTime = new DateTime(d[0], d[1], d[2], d[3], 0, 0),
                            Total = x.Sum(y => y.Total)
                        };
                    });
            }
        }

        public static IEnumerable<VisitsByDateTime> VisitsByDay
        {
            get
            {
                return Visits.GroupBy(x => string.Format("{0}*{1}*{2}",
                    x.DateTime.Year, x.DateTime.Month, x.DateTime.Day))
                    .Select(x =>
                    {
                        var d = x.Key.Split('*').Select(int.Parse).ToArray();
                        return new VisitsByDateTime
                        {
                            DateTime = new DateTime(d[0], d[1], d[2], 0, 0, 0),
                            Total = x.Sum(y => y.Total)
                        };
                    });
            }
        }
    }
}