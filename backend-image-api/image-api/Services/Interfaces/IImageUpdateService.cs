using image_api.Models;

namespace image_api.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageUpdateService
    {
        Task<Image> UpdateImage(int id, Image image);
    }
}
