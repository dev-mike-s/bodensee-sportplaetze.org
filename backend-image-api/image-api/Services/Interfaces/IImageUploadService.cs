using image_api.Models;

namespace image_api.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageUploadService
    {
        public Task<Image> UploadImageAsync(Image image);

    }
}
