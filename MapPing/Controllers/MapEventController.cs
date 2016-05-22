using MapPing.Models;
using MapPing.Services.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MapPing.Controllers
{
    public class MapEventController : ApiController
    {
        private readonly IGeoService geoService;
        private readonly IEventHub hub;
        private readonly IRepository repo;

        public MapEventController(IEventHub hub, IRepository repo, IGeoService geoService)
        {
            this.hub = hub;
            this.repo = repo;
            this.geoService = geoService;
        }


        public Task CheckEvents()
        {
            //Check data source for events
            //Queue events
            //Push to web client

            var events = repo.GetMapEvents();
            var rand = new System.Random();

            var task = Task.Run(async () =>
            {
                foreach (var e in events)
                {
                    hub.SendEvent(e);
                    await Task.Delay(rand.Next(100, 3000));

                }
            });

            return task;
        }

        public async Task Event(IPEvent ipEvent)
        {
            var location = await geoService.GetLocationAsync(ipEvent.IPAdress);

            var mapEvent = new MapEvent(location.Latitude, location.Longitude, ipEvent.Value);

            hub.SendEvent(mapEvent);
        }

    }
}
