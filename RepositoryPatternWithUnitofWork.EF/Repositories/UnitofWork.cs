using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfwork.Core;
using RepositoryPatternWithUnitOfwork.Core.Interfaces;
using RepositoryPatternWithUnitOfwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitofWork.EF.Repositories
{
    public class UnitofWork : IUnitofwork
    {
        private readonly AppDBcontext _dbcontext;

        public UnitofWork(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IGenericRepository<Author> Authors { get; private set; }

        public IGenericRepository<Book> Books { get; private set; }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
