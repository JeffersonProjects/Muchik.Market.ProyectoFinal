using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using muchik.market.invoice.domain.entities;

namespace muchik.market.invoice.infraestructure.configurations.entityTypes
{
    public class InvoiceTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");

            builder.Property(e => e.Id_Invoice).HasColumnName("id_invoice");

            builder.HasKey(e => e.Id_Invoice);

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");

            builder.Property(e => e.State)
                .HasColumnType("int")
                .HasColumnName("state");
        }
    }
}
