using Microsoft.EntityFrameworkCore;
using dotnet_api.Models;

namespace dotnet_api.Data
{
    /// <summary>
    /// Test DB for quick prototyping and dual data source practice.
    /// </summary>
    public class InMemoryDb : DbContext
    {
        public InMemoryDb(DbContextOptions<InMemoryDb> options) : base(options) { }
        public DbSet<Image> Images { get; set; } = default!;
    }
}
