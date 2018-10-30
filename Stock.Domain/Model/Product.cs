using System;
using SharedKernel.Model;
using Stock.Domain.Events;
using Tnf.Repositories.Entities;

namespace Stock.Domain.Model
{
    public class Product : Aggregate, IMustHaveTenant
    {
        public string Name { get; private set; }
        public long Quantity { get; private set; }
        public int TenantId { get; set; }

        public Product(string name, long quantity, int tenantId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Quantity = quantity;
            TenantId = tenantId;

            AddEvent(new ProductCreated(Id, Name, Quantity, TenantId));
        }

        public void Add(int quantity)
        {
            var previousQuantity = Quantity;

            Quantity += quantity;

            AddEvent(new ProductQuantityChanged(Id, previousQuantity, Quantity));
        }

        public void UpdateQuantity(long quanity)
        {
            var previousQuantity = Quantity;

            Quantity = quanity;

            AddEvent(new ProductQuantityChanged(Id, previousQuantity, Quantity));
        }

        public Reservation MakeReservation(int quantity, Guid orderId)
        {
            if (Quantity >= quantity)
            {
                var reservation = new Reservation(Id, quantity, orderId);

                AddEvent(new ProductReservationMade(Id, reservation.Id, orderId, quantity));

                var previousQuantity = Quantity;
                Quantity = Quantity - quantity;

                AddEvent(new ProductQuantityChanged(Id, previousQuantity, Quantity));

                return reservation;
            }
            else
            {
                AddEvent(new ProductReservationFailed(Id, orderId, quantity, Quantity));

                return null;
            }
        }
    }
}
