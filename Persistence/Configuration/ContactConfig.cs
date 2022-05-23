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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description)
                .HasMaxLength(12)
                .IsRequired();
            builder.Property(c => c.ClientId)
                .IsRequired();
            //builder.Property(c => c.ContactType)
            //    .IsRequired();
        }
    }
}
