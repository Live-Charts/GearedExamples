using System;
using System.Collections.Generic;

namespace WpfGeared.Histogram
{
    public static class DataProvider
    {
        public static IEnumerable<double> GetNormalDistribution(double variance, double expectation, int ticks)
        {
            var teoricalVariance = 3 * variance;
            var step = (expectation + teoricalVariance - (expectation - teoricalVariance)) / ticks;

            for (var x = expectation-teoricalVariance; x <= expectation + teoricalVariance; x += step)
            {
                yield return
                    (1 / (variance * Math.Pow(2 * Math.PI, -2))) *
                    Math.Pow(Math.E, -0.5 * Math.Pow((x - expectation) / variance, 2));
            }
        }
    }
}
