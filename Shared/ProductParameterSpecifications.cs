using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductParameterSpecifications
    {
        public ProductSortOption? sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
       
    }
    public enum ProductSortOption
    {
        NameAsc, NameDesc , PriceAsc , PriceDesc
    }
}
