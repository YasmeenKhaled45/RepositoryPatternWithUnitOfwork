using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitofWork.EF
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
