using Microsoft.EntityFrameworkCore;
using FillSign.Ds.Domain;
using FillSign.Ds.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FillSign.Ds.Data
{
    public class ApiDbContext : IdentityDbContext , IApiDbContext
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
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(u => u.UserId);
        }
    }
}
