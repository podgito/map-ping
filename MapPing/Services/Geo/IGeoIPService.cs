using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapPing.Services.Geo
{
    public interface IGeoService
    {

        Location GetLocation(string ipAddress);
        Task<Location> GetLocationAsync(string ipAddress);


    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }


}
