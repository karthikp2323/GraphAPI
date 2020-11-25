using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoDAL.Model
{
    public partial class SampleContext : DbContext
    {
        public SampleContext()
        {
        }

        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
