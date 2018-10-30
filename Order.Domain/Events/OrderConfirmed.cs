using System;
using System.Collections.Generic;

namespace Ordering.Domain.Events
{
    public class OrderConfirmed
    {
        public OrderConfirmed(Guid orderId, IEnumerable<OrderItem> items, Guid customerId)
        {

        }
    }

    public class OrderItem
    {
        public OrderItem(Guid id, Guid productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
    }
}
