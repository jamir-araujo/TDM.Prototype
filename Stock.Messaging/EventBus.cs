using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Messaging
{
    public class EventBus : IEventBus
    {
        public Task PublishAsync(IEvent @event)
        {
            return @event.Publish();
        }

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                await @event.Publish();
            }
        }
    }
}
