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
    public  class DocumentMapping : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(800);
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.Attach).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();    

            builder.ToTable("Document");


            builder
            .HasMany(d => d.Signers)
            .WithMany(s => s.Documents)
            .UsingEntity<DocumentSigner>(
                j => j
                    .HasOne(ds => ds.Signer)
                    .WithMany()
                    .HasForeignKey(ds => ds.SignerId),
                j => j
                    .HasOne(ds => ds.Document)
                    .WithMany()
                    .HasForeignKey(ds => ds.DocumentId),
                j =>
                {
                    j.HasKey(ds => new { ds.DocumentId, ds.SignerId });
                    j.ToTable("DocumentSigner");
                }
            );
        }
    }
    public class DocumentSignerMapping : IEntityTypeConfiguration<DocumentSigner>
    {
        public void Configure(EntityTypeBuilder<DocumentSigner> builder)
        {
            builder.HasKey(ds => new { ds.DocumentId, ds.SignerId });

            builder.HasOne(ds => ds.Document)
                .WithMany(d => d.DocumentSigners)
                .HasForeignKey(ds => ds.DocumentId);

            builder.HasOne(ds => ds.Signer)
                .WithMany(s => s.DocumentSigners)
                .HasForeignKey(ds => ds.SignerId);
        }
    }
}
