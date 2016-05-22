using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MapPing.Services.Geo
{
    public class FreeGeoIPDotNetService : IGeoService
    {
        public Location GetLocation(string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<Location> GetLocationAsync(string ipAddress)
        {
            var client = new HttpClient();
            var jsonString = await client.GetStringAsync(string.Format("freegeoip.net/json/{0}", ipAddress));
            return JsonConvert.DeserializeObject<Location>(jsonString);

        }
    }
}