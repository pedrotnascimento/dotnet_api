using Moq;
using PedroApi.Models;
using PedroApi.Repositories;
using PedroApi.Services;

namespace TestProject
{
    public class CustomerTest
    {
        private Mock<ICustomerRepository> _repository = new Mock<ICustomerRepository>();
        

        [Fact()]
        public void ShouldRetrieveACustomer()
        {
            Customers expect = new Customers { Balance = 1, CustomerId = 1, Name = "John Doe" };
            _repository.Setup<Customers?>(x=> x.FindOne(It.IsAny<long>())).Returns(expect);
            CustomerService customerService = new CustomerService(_repository.Object);

            var result = customerService.FindCustomer(expect.CustomerId);

            Assert.Equal(expect.CustomerId, result?.CustomerId);
            Assert.Equal(expect.Balance, result?.Balance);
            Assert.Equal(expect.Name, result?.Name);
        }

        [Fact()]
        public void ShouldNotFindACustomer()
        {
            Customers? value = null;
            _repository.Setup<Customers?>(x=> x.FindOne(It.IsAny<long>())).Returns(value);
            CustomerService customerService = new CustomerService(_repository.Object);

            var result = customerService.FindCustomer(1);

            Assert.Equal(value, result);
            Assert.Null(result);
            
        }
    }
}