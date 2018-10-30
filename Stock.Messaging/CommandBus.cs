using System.Collections.Generic;
using System.Threading.Tasks;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Messaging
{
    public class CommandBus : ICommandBus
    {
        public Task PublishAsync(ICommand command)
        {
            return command.Publish();
        }

        public async Task PublishAsync(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                await command.Publish();
            }
        }
    }
}
