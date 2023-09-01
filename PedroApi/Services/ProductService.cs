using PedroApi.Models;
using PedroApi.Repositories;

namespace PedroApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Products? FindProduct(long productId)
        {
            return _productRepository.FindOne(productId);
        }
    }
}
