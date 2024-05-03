using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Context
{
    //Define o mapeamento ORM
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        { }

        public DbSet<User> Users { get; set; }
    }
}
