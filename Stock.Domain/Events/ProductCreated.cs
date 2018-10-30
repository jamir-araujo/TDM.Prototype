using System;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Events
{
    public class ProductCreated : Message, IEvent
    {
        public ProductCreated(Guid productId, string name, long quantity, int tenantId)
        {
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            TenantId = tenantId;
        }

        public Guid ProductId { get; }
        public string Name { get; }
        public long Quantity { get; }
        public int TenantId { get; }
    }
}
