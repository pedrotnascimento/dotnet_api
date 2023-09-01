using PedroApi.Models;

namespace PedroApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository() { }

        public Products? FindOne(long productId)
        {
            Products? product = null;
            using (var context = new OrderApiDatabasedbContext())
            {
                product = context.Products.FirstOrDefault(x => x.ProductId == productId);
            }
            return product;
        }
    }
}
