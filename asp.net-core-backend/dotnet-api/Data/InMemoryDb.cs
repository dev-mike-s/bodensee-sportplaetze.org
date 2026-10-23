using Microsoft.EntityFrameworkCore;
using dotnet_api.Models;

namespace dotnet_api.Data
{
    public class ImageDb : DbContext
    {
        public ImageDb(DbContextOptions<ImageDb> options) : base(options) { }
        public DbSet<Image> Images { get; set; } = default!;
    }
}
