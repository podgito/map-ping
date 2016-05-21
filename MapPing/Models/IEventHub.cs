using Microsoft.AspNet.SignalR;
using System;

namespace MapPing.Models
{
    public interface IEventHub
    {

        void SendEvent(MapEvent @event);

    }

    public class EventHub : IEventHub
    {
        private readonly IHubContext hubContext;

        public EventHub(IHubContext hubContext)
        {
            this.hubContext = hubContext;
        }

        public void SendEvent(MapEvent @event)
        {
            hubContext.Clients.All.sendEvent(@event);
        }
    }

}
