using Microsoft.EntityFrameworkCore;
using muchik.market.pay.domain.entities;
using muchik.market.pay.infraestructure.configurations.entityTypes;

namespace muchik.market.pay.infraestructure.context
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
