namespace MapPing.Models
{
    public class MapEvent
    {
       public double lat { get; set; }
       public double lon { get; set; }
        public double value { get; set; }

        public MapEvent(double lat, double lon, double value)
        {
            this.lat = lat;
            this.lon = lon;
            this.value = value;
        }
    }
}