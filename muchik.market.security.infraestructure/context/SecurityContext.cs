using Microsoft.EntityFrameworkCore;
using muchik.market.security.domain.entities;
using muchik.market.security.infraestructure.configurations.entityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.infraestructure.context
{
    public partial class SecurityContext : DbContext
    {
        

        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; } = null!;
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
