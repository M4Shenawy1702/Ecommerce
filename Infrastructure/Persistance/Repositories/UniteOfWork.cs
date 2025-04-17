using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repository;

        public UniteOfWork(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _repository = new();
        }

        public IGenaricRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            // return new GenericRepository <TEntity , Tkey>[_dbcontext];
            //Dictionary [Collection]
            //Repositories 
            // key     : value 
            // Product : new GenericRepositories<Product , int>

            // var typeName = typeof (TEntity).Name;// KEy 
            // if (_repository.ContainKey(typeName))
            // return (IGenaricRepository<TEntity, TKey>) _repository[typeName];
            // Else
            // {
            // var repo = new GenaricRepository<TEntity, TKey> (_dbContext)
            // _repository.Add(typeName,repo);
            // return repo;
            // }
            return (IGenaricRepository<TEntity, TKey>)_repository.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, TKey>(_dbContext));

        }

        public async Task<int> SaveChangesAsync()=> await _dbContext.SaveChangesAsync();
      
    }
}
