using Microsoft.AspNetCore.Mvc;
using PedroApi.DTO;
using PedroApi.Services;

namespace PedroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public ProductGet Get(long productId)
        {
            var productData = _productService.FindProduct(productId);
            ProductGet productResponse = new ProductGet();
            if (productData != null)
            {
                productResponse.ProductId = productData.ProductId;
                productResponse.Name = productData.Name;
                productResponse.Price = productData.Price;
                productResponse.Quantity = productData.Quantity;
            }
            return productResponse;
        }
    }
}