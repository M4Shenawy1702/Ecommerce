using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenaricRepository<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {
        // getbyID , GetAll , Update , Add , Delete 
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false );
        Task<TEntity> GetByIdAsync(Specifcation<TEntity> specifcation);
        Task<IEnumerable<TEntity>> GetAllAsync(Specifcation<TEntity> specifcation);
        Task AddAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
    }
}
