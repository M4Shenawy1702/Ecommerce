using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifcations: Specifcation<Product>
    {
        // reterive product by id where {id} , include [brands * Types]

        public ProductWithBrandAndTypeSpecifcations(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
        public ProductWithBrandAndTypeSpecifcations(ProductParameterSpecifications parameters) 
            : base(product=>
            (!parameters.BrandId.HasValue|| product.BrandId == parameters.BrandId.Value)
            &&
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            if ( parameters.sort is not null )
            {
                switch (parameters. sort)
                {
                    case ProductSortOption.PriceDesc:
                        SetbyDesc(product => product.Price);
                        break;
                    case ProductSortOption.PriceAsc:
                        SetOrderby(product => product.Price);
                        break;
                    case ProductSortOption.NameDesc:
                        SetbyDesc(product => product.Name);
                        break;
                    default:
                        SetOrderby(product => product.Name);
                        break;

                }
            }
        }

        // reterive all product {includ brands and type
        // }
    }
}
