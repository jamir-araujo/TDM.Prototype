using System;

namespace Stock.Domain.Model
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Guid OrderId { get; }

        public Reservation(Guid productId, int quantity, Guid orderId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}
