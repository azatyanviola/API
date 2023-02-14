using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
    public class MyProjectContext : DbContext
    {
        public MyProjectContext (DbContextOptions<MyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MyProject.Models.Category> Category { get; set; } = default!;
    }
}
