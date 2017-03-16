using LiveCharts;
using LiveCharts.Configurations;

namespace Geared.Winforms.Scatter
{
    public class CustomScatterPoint
    {
        static CustomScatterPoint()
        {
            //in this case we are using a custom type
            //just to have more control
            //here I am not implementing IObservableChartPoint
            //to gain some performance

            //finally we teach LiveCharts to plot this type
            //you can find more information about this step here:
            //https://lvcharts.net/App/examples/v1/wpf/Types%20and%20Configuration

            var mapper = Mappers.Xy<CustomScatterPoint>()
                .X(point => point.X)
                .Y(point => point.Y);

            Charting.For<CustomScatterPoint>(mapper);
        }

        public CustomScatterPoint()
        {
        }

        public CustomScatterPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}