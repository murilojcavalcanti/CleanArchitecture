using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    //Implementa IUnitOfWork
    //Usando o Unit Of Work, ele espera que todas as alterações no db sejam confirmadas, garantindo o uso de um mesmo contexto
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Context;
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }
        public async Task Commit(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
