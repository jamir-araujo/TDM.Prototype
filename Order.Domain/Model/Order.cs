using System;
using System.Collections.Generic;
using SharedKernel;
using SharedKernel.Model;
using Tnf.Repositories.Entities;

namespace Ordering.Domain.Model
{
    public class Order : IAggregate, IMustHaveTenant
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public int TenantId { get; set; }

        public IReadOnlyCollection<IEvent> UnpublishedEvents => throw new NotImplementedException();

        public void Confirm()
        {
        }
    }

    public enum OrderState
    {
        Open,
        Processing,
        Canceled,
    }
}
