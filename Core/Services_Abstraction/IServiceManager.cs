using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Abstraction
{
    public interface IServiceManager
    {
        public  IProductService ProductService { get; }
    }
}
