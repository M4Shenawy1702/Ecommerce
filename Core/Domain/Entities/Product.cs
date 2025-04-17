using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        //Id
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        // navigation property one 
        public ProductBrand ProductBrand { get; set; }
        //FK
        public int BrandId { get; set; }
        // navigation property two 
        public ProductType ProductType { get; set; }
        //Fk
        public int TypeId { get; set; }


    }
}
