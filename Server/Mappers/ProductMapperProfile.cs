using AutoMapper;
using Server.Entities;
using Server.Entities.DTOs;

namespace Server.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>();           // Entity -> ProductDto
            CreateMap<ProductCreateDto, Product>();     // ProductCreateDto -> Entity
            CreateMap<ProductUpdateDto, Product>();     // ProductUpdateDto -> Entity
        }
    }
}