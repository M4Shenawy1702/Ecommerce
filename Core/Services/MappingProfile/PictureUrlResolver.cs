using AutoMapper;
using AutoMapper.Execution;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductResult_DTO, string>
    {
        public string Resolve(Product source, ProductResult_DTO destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.PictureUrl))return string.Empty;
            // return $"https://localhost:44369/{source.PictureURL}";
            return $"{configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
