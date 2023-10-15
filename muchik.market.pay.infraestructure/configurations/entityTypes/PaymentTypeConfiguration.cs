using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using muchik.market.pay.domain.entities;

namespace muchik.market.pay.infraestructure.configurations.entityTypes
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(e => e.Id_Operation).HasColumnName("id_operation");

            builder.HasKey(e => e.Id_Operation);

            builder.Property(e => e.Id_Invoice)
                .HasColumnType("int")
                .HasColumnName("id_invoice");

             builder.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
        }
    }
}
