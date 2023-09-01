using AutoMapper;
using PedroApi.DTO;
using PedroApi.Models;
using PedroApi.Repositories;

namespace PedroApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ProductDto? FindProduct(long productId)
        {
            var product = _productRepository.FindOne(productId);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
