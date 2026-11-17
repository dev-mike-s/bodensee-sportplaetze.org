using image_api.Models;

namespace image_api.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for a service that handles image display CRUD-operations.
    /// </summary>
    public interface IImageDisplayService
    {
        Task<IEnumerable<Image>> GetImages();
        Task<Image> GetImageById(int id);
    }
}