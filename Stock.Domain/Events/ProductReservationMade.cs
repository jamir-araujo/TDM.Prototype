using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Events
{
    public class ProductReservationMade : Message, IEvent
    {
        public ProductReservationMade(Guid productId, Guid reservationId, Guid orderId, int quantity)
        {
            ProductId = productId;
            ReservationId = reservationId;
            OrderId = orderId;
            Quantity = quantity;
        }

        public Guid ProductId { get; set; }
        public Guid ReservationId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
