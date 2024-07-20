using NetTopologySuite.Geometries;
using NetTopologySuite;

namespace FishingApp.Models
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Point ToPoint()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return geometryFactory.CreatePoint(new Coordinate(Longitude, Latitude));
        }

        public static GeoPoint FromPoint(Point point)
        {
            return new GeoPoint
            {
                Latitude = point.Y,
                Longitude = point.X
            };
        }
    }
}
