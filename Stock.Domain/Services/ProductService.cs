using System;
using System.Threading.Tasks;
using SharedKernel;
using Stock.Domain.Model;
using Tnf.Repositories;

namespace Stock.Domain.Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(string name, long quaintity, int tenantId);
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IEventBus _eventBus;

        public ProductService(IRepository<Product> repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task<Product> CreateProductAsync(string name, long quaintity, int tenantId)
        {
            var product = new Product(name, quaintity, tenantId);

            product = await _repository.InsertAndSaveChangesAsync(product);
            await _eventBus.PublishAsync(product.UnpublishedEvents);

            return product;
        }
    }
}
