using FillSign.Ds.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillSign.Ds.Data.Mappings
{
    public class SignerMapping : IEntityTypeConfiguration<Signer>
    {
        public void Configure(EntityTypeBuilder<Signer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.ToTable("Signer");
        }
    }
}
