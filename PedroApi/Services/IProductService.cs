using PedroApi.DTO;
using PedroApi.Models;

namespace PedroApi.Services
{
    public interface IProductService
    {
        ProductDto? FindProduct(long productId);
    }
}