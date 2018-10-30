using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Events
{
    public class ProductReservationFailed : Message, IEvent
    {
        public ProductReservationFailed(Guid productId, Guid orderId, int issuedQuantity, long remainingQuantity)
        {
            ProductId = productId;
            OrderId = orderId;
            IssuedQuantity = issuedQuantity;
            RemainingQuantity = remainingQuantity;
        }

        public Guid ProductId { get; }
        public Guid OrderId { get; }
        public int IssuedQuantity { get; }
        public long RemainingQuantity { get; }
    }
}
