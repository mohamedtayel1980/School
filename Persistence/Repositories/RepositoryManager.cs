using Utilities.Sorting;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Helpers;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IStudentRepository> _lazyStudentRepository;
        //private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly ISortHelper<Student> _studentSortHelper;
        private readonly IDataShaper<Student> _studentDataShaper;
        public RepositoryManager(RepositoryContext dbContext, 
            ISortHelper<Student> studentSortHelper,
            IDataShaper<Student> studentDataShaper)
        {
            _studentSortHelper = studentSortHelper;
            _studentDataShaper = studentDataShaper;
            _lazyStudentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(dbContext,
                _studentSortHelper,
                _studentDataShaper));
            //_lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _studentSortHelper = studentSortHelper;
        }
        public IStudentRepository StudentRepository => _lazyStudentRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
