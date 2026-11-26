using image_api.Services.Interfaces;
using image_api.Models;

namespace image_api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ImageUpdateService : IImageUpdateService
    {
        public async Task<Image> UpdateImage(Guid id, Image image)
        {
            throw new NotImplementedException();
        }
    }
}
