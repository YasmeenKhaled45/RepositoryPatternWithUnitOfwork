using RepositoryPatternWithUnitOfwork.Core.Interfaces;
using RepositoryPatternWithUnitOfwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfwork.Core
{
    public interface IUnitofwork : IDisposable
    {
        IGenericRepository<Author> Authors { get; }
        IGenericRepository<Book> Books { get; }
        int SaveChanges();

    }
}
