namespace MapPing.Models
{
    public class MapEvent
    {
       public double lat { get; set; }
       public double lon { get; set; }
        public double z { get; set; }

        public MapEvent(double lat, double lon, double value)
        {
            this.lat = lat;
            this.lon = lon;
            this.z = value;
        }
    }
}