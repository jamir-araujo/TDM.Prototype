using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Commands
{
    public class MakeProductReservationCommand : Message, ICommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}
