using Microsoft.EntityFrameworkCore;
using FillSign.Ds.Application.Models;

namespace FillSign.Ds.Domain.Data
{
    public class ApiDbContext : DbContext , IApiDbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Signer> Signers { get; set; }
    }
}
