using MapPing.Models;
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
        private readonly IEventHub hub;
        private readonly IRepository repo;

        public MapEventController(IEventHub hub, IRepository repo)
        {
            this.hub = hub;
            this.repo = repo;
        }


        public void CheckEvents()
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



        }

    }
}
