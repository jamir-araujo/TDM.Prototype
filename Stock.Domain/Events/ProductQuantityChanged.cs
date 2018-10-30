using System;
using SharedKernel;
using Tnf.Bus.Client;

namespace Stock.Domain.Events
{
    public class ProductQuantityChanged : Message, IEvent
    {
        public ProductQuantityChanged(Guid productId, long previousQuantity, long newQuantity)
        {
            ProductId = productId;
            PreviousQuantity = previousQuantity;
            NewQuantity = newQuantity;
        }

        public Guid ProductId { get; set; }
        public long PreviousQuantity { get; set; }
        public long NewQuantity { get; set; }
    }
}
