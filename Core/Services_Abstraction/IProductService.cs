using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Abstraction
{
    public interface IProductService
    {
        // get all product 
        public Task<IEnumerable<ProductResult_DTO>> GetAllProductAsync(ProductParameterSpecifications parameters);
        // get all brands 
        public Task<IEnumerable<BrandRsult_DTO>> GetAllBrandAsync();
        // get all types
        public Task<IEnumerable<TypeResult_DTO>> GetAllTypeAsync();
        // get product by id 
        public Task<ProductResult_DTO> GetProductByIdAsync(int id);
    }
}
