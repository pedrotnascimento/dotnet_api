using AutoMapper;
using Moq;
using PedroApi;
using PedroApi.Models;
using PedroApi.Repositories;
using PedroApi.Services;

namespace TestProject
{
    public class ProductTest
    {
        private Mock<IProductRepository> _repository = new Mock<IProductRepository>();
        private readonly IMapper _mapper;

        public ProductTest()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfiles());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact()]
        public void ShouldRetrieveAProduct()
        {
            Products expect = new Products { Price = 1, ProductId = 1, Name = "My Product" };
            _repository.Setup<Products?>(x=> x.FindOne(It.IsAny<long>())).Returns(expect);
            ProductService customerService = new ProductService(_repository.Object, _mapper);

            var result = customerService.FindProduct(expect.ProductId);

            Assert.Equal(expect.ProductId, result?.ProductId);
            Assert.Equal(expect.Price, result?.Price);
            Assert.Equal(expect.Name, result?.Name);
        }

        [Fact()]
        public void ShouldNotFindAProduct()
        {
            Products? value = null;
            _repository.Setup<Products?>(x=> x.FindOne(It.IsAny<long>())).Returns(value);
            ProductService customerService = new ProductService(_repository.Object, _mapper);

            var result = customerService.FindProduct(1);
            Assert.Null(result);
        }
    }
}