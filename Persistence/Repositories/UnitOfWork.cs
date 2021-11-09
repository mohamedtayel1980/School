using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _dbContext;

        public UnitOfWork(RepositoryContext dbContext) => _dbContext = dbContext;
        public int SaveChanges() => _dbContext.SaveChanges();


    }
}
