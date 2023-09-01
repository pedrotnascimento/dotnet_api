using PedroApi.Models;

namespace PedroApi.Repositories
{
    public interface IProductRepository
    {
        Products? FindOne(long productId);
    }
}