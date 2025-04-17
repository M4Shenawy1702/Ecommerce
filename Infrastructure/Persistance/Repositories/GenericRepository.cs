using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    // GenericRepository<Product , int>
    // GenericRepository<ProductBrand , int>
    // GenericRepository<ProductType , int>

    internal class GenericRepository<TEntity, Tkey> : IGenaricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
        
        public void DeleteAsync(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void UpdateAsync(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false ) => asNoTracking ? 
            await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync() // true
            : await _dbContext.Set<TEntity>().ToListAsync();// false
        public async Task<TEntity> GetByIdAsync(Tkey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        

        private IQueryable<TEntity> ApplySpecifcation(Specifcation<TEntity> specifcations)
            => SpecificationEvaluator.GetQuery<TEntity>(_dbContext.Set<TEntity>(), specifcations);

        public async Task<TEntity> GetByIdAsync(Specifcation<TEntity> specifcation)
        {
           return await ApplySpecifcation(specifcation).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Specifcation<TEntity> specifcation)
        {
           return await ApplySpecifcation(specifcation).ToListAsync();
        }

        //public async Task<IEnumerable<TEntity>> GetAllAsync(Specifcation<TEntity> specifcation) 
        //    => await ApplySpecifcation(specifcation).ToListAsync();

        //public async Task<TEntity> GetByIdAsync(Specifcation<TEntity> specifcation) 
        //    => await ApplySpecifcation(specifcation).FirstOrDefaultAsync();


    }
}
