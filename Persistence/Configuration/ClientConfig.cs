using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.BirtDate)
                .IsRequired();
            builder.Property(x => x.Gender)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasMany(x => x.Contact);
        }
    }
}
