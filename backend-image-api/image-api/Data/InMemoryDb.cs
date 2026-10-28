using Microsoft.EntityFrameworkCore;
using image_api.Model;

namespace image_api.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryDb : DbContext
    {
        public InMemoryDb(DbContextOptions<InMemoryDb> options): base(options) { }

        public DbSet<Image> Images { get; set; } = default!;
    }
}
