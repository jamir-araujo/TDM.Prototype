using System;
using Stock.Domain.Model;

namespace Stock.WebApi.DTOs
{
    public class ProductDto
    {
        public ProductDto(Product product)
        {
            ProductId = product.Id;
            Name = product.Name;
            Quantity = product.Quantity;
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
    }
}
