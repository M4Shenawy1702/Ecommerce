using AutoMapper;
using Domain.Entities;
using Shared.DTOS;

namespace Services.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductResult_DTO>()
                .ForMember(d => d.BrandName, option => option.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.TypeName, option => option.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, option => option.MapFrom<PictureUrlResolver>());


            CreateMap<ProductBrand, BrandRsult_DTO>();
            CreateMap<ProductType, TypeResult_DTO>();
        }
    }
}
