using System;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Commands
{
    public class CancelProductReservationsCommand : Message, ICommand
    {
        public Guid OrderId { get; set; }
    }
}
