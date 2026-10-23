using Microsoft.EntityFrameworkCore;
using dotnet_api.Models;

namespace dotnet_api.Data
{
    public class PostgresDb : DbContext
    {
        public PostgresDb(DbContextOptions<PostgresDb> options) : base(options) { }
        public DbSet<Image> Images { get; set; } = default!;

    }
}
