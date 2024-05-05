using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    //Implementa IBaseRepository
    internal class BaseRepository<T>:IBaseRepository <T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.Now;
            Context.Add(entity);
        }
        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.Now;
            Context.Update(entity);
        }
        
        public void Delete(T entity)
        {
           entity.DateDeleted = DateTimeOffset.Now;
           Context.Remove(entity);
        }

        public async Task<List<T>> GetAll( CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
