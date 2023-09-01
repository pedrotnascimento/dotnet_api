using PedroApi.Models;

namespace PedroApi.Services
{
    public interface IProductService
    {
        Products? FindProduct(long productId);
    }
}