using AutoMapper;
using Domain.Contracts;
using Services_Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        public ServiceManager(IUniteOfWork uniteofwork ,IMapper mapper) 
        {
            _productService = new Lazy<IProductService>(() => new ProductService(uniteofwork, mapper));
        }
        public IProductService ProductService => _productService.Value;
    }
}
