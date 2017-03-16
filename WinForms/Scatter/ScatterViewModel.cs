using System;
using System.ComponentModel;
using System.Linq;
using LiveCharts.Geared;

namespace Geared.Winforms.Scatter
{
    public class ScatterViewModel
    {
        public ScatterViewModel()
        {
            BuildRandomData();
        }

        public GearedValues<CustomScatterPoint> Values1 { get; set; }

        public GearedValues<CustomScatterPoint> Values2 { get; set; }

        public void BuildRandomData()
        {
            var r = new Random();

            const int points = 3000;

            var v1 = new double[points][];
            var v2 = new double[points][];

            for (var i = 0; i < points; i++)
            {
                v1[i] = new [] {NormalDist(500, 300, r), NormalDist(500, 200, r)};
                v2[i] = new [] {NormalDist(400, 200, r), NormalDist(350, 280, r)};
            }

            Values1 = v1.Select(x => new CustomScatterPoint(x[0], x[1]))
                .AsGearedValues()
                .WithQuality(Quality.Medium);
            Values2 = v2.Select(x => new CustomScatterPoint(x[0], x[1]))
                .AsGearedValues()
                .WithQuality(Quality.Medium);
        }

        //Based on:
        //http://stackoverflow.com/questions/218060/random-gaussian-variables
        private static double NormalDist(double average, double variance, Random seed)
        {
            var u1 = 1.0 - seed.NextDouble();
            var u2 = 1.0 - seed.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *Math.Sin(2.0 * Math.PI * u2);
            return average + variance * randStdNormal;
        }
    }
}
