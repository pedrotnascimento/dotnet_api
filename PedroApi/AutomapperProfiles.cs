using AutoMapper;
using PedroApi.DTO;
using PedroApi.Models;
using PedroApi.ViewModels;

namespace PedroApi
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Customers, CustomerDto>();
            CreateMap<Products, ProductDto>();
            CreateMap<ProductDto, ProductGet>();
            CreateMap<CustomerDto, CustomerGet>();
        }
    }
}
