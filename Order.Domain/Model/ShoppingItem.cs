using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Model
{
    public class ShoppingItem
    {
        public Guid Id { get; private set; }
        public Guid ShoppingCardId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
    }
}
