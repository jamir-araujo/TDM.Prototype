using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Model;
using Stock.Domain.Services;
using Stock.WebApi.DTOs;
using Tnf.AspNetCore.Mvc.Response;
using Tnf.Repositories;
using Tnf.Runtime.Session;

namespace Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : TnfController
    {
        private readonly ITnfSession _session;
        private readonly IRepository<Product> _repository;
        private readonly IProductService _productServices;

        public ProductController(
            ITnfSession session,
            IRepository<Product> repository,
            IProductService productServices)
        {
            _session = session;
            _repository = repository;
            _productServices = productServices;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var product = await _repository.SingleAsync(p => p.Id == id);

            return CreateResponseOnGet(new ProductDto(product));
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(CreateProductDto), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductDto value)
        {
            var product = await _productServices.CreateProductAsync(value.Name, value.Quantity, 2);

            return CreateResponseOnPost(new ProductDto(product));
        }
    }
}
