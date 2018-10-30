using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface ICommandBus
    {
        Task PublishAsync(ICommand command);
        Task PublishAsync(IEnumerable<ICommand> commands);
    }
}
