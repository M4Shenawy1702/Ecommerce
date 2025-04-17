using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUniteOfWork
    {
        // savechanges
        Task<int> SaveChangesAsync();
        //Signature for function will return an instance of class that implement IgenericRepo
        // new GenericRepository<ProductBrand , int >
        // new genericrepository<ProductType , int >
        // new genericrepository<Product, int >
      IGenaricRepository<TEntity , TKey> GetRepository<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
      
    }
}
