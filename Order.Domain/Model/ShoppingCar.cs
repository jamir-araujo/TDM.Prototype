using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;
using SharedKernel.Model;
using Tnf.Repositories.Entities;

namespace Ordering.Domain.Model
{
    public class ShoppingCar : IAggregate, IMustHaveTenant
    {
        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }
        public IReadOnlyCollection<IEvent> UnpublishedEvents => throw new NotImplementedException();
        public int TenantId { get; set; }

        public ShoppingCar(Customer customer)
        {
            Customer = customer;
        }
    }
}
