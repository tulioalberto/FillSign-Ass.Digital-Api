using Microsoft.EntityFrameworkCore;
using FillSign.Ds.Domain;
using FillSign.Ds.Data.Mappings;

namespace FillSign.Ds.Data
{
    public class ApiDbContext : DbContext , IApiDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Signer> Signers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentMapping());
            modelBuilder.ApplyConfiguration(new SignerMapping());
            modelBuilder.ApplyConfiguration(new DocumentSignerMapping());
        }
    }
}
