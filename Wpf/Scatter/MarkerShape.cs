using System;
using System.Windows;
using System.Windows.Media;
using LiveCharts.Geared.Geometries;

namespace Geared.Wpf.Scatter
{
    public class MarkerShape : GeometryShape
    {
        private PathFigure _figure;
        private LineSegment[] _segments;

        /// <summary>
        /// Draws the specified path.
        /// </summary>
        /// <param name="path">The path that holds the series</param>
        /// <param name="location">The coordinates of the points that is currently being drawn</param>
        /// <param name="animate">Sets if the chart requires animations</param>
        /// <param name="animationsSpeed">The animations speed</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Draw(PathGeometry path, Point location, bool animate, TimeSpan animationsSpeed)
        {
            if (_figure == null) Initialize(path);

            //location is the coordinate of the point being drawn.

            var r = Diameter / 2;

            if (animate)
            {
                //animate your shape??
                //_figure.BeginAnimation(PathFigure.StartPointProperty,
                //    new PointAnimation(new Point(location.X - r, location.Y - r), animationsSpeed));

                throw new NotImplementedException();
            }

            //Data="M0,2 L0,0 L-0.5,-2 L0.5,-2 L0,0 Z"
            _figure.StartPoint = new Point(location.X, location.Y);
            _segments[0].Point = new Point(location.X - r, location.Y - r);
            _segments[1].Point = new Point(location.X + r, location.Y - r);
            _segments[2].Point = new Point(location.X, location.Y);
            _segments[3].Point = new Point(location.X, location.Y + r);
        }

        /// <summary>
        /// Erases the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public override void Erase(PathGeometry path)
        {
            path.Figures.Remove(_figure);
            _figure = null;
        }

        private void Initialize(PathGeometry path)
        {
            _segments = new []
            {
                new LineSegment(),
                new LineSegment(),
                new LineSegment(),
                new LineSegment()
            };

            _figure = new PathFigure
            {
                Segments = new PathSegmentCollection(4)
            };

            foreach (var segment in _segments) _figure.Segments.Add(segment);

            path.Figures.Add(_figure);
        }
    }
}
