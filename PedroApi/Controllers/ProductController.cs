using Microsoft.AspNetCore.Mvc;
using PedroApi.ViewModels;
using PedroApi.Services;
using AutoMapper;

namespace PedroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public ProductGet Get(long productId)
        {
            var productData = _productService.FindProduct(productId);
            ProductGet productResponse = new ProductGet();
            if(productData != null)
            {
                productResponse  = _mapper.Map<ProductGet>(productData);
            }
            
            return productResponse;
        }
    }
}