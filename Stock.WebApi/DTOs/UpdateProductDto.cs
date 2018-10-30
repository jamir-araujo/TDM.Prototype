using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.WebApi.DTOs
{
    public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
    }
}
