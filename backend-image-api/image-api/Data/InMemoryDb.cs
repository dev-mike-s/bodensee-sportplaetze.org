using Microsoft.EntityFrameworkCore;
using image_api.Models;

namespace image_api.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryDb : DbContext
    {
        #region --- PROPERTIES ---

        public InMemoryDb(DbContextOptions<InMemoryDb> options): base(options) { }

        public DbSet<Image> Images { get; set; } = default!;

        #endregion
        #region --- CONSTRUCTOR ---

        public InMemoryDb()
        {

        }

        #endregion
        #region --- PUBLIC METHODS ---

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            return await Images.ToListAsync();
        }

        public async Task<Image> AddImageAsync(Image image)
        {
            await Images.AddAsync(image);
            await SaveChangesAsync();
            return image;
        }

        public async Task<Image>DeleteImageAsync(int id, Image image)
        {
            await Images.FindAsync(id);
            await SaveChangesAsync();
            return image;
        }

        #endregion
        #region --- PRIVATE METHODS ---
        #endregion
    }
}
