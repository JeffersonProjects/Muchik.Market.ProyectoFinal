using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muchik.market.security.domain.entities;

namespace muchik.market.security.infraestructure.configurations.entityTypes
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("security");

            builder.Property(e => e.id_user)
                .HasColumnName("id_user");

            builder.HasKey(c => c.id_user);

            builder.Property(e => e.username)
                .HasColumnType("username")
                .HasMaxLength(100)
                .HasColumnName("username");

            builder.Property(e => e.password)
                .HasMaxLength(100)
                .HasColumnName("password");
        }
    }
}
