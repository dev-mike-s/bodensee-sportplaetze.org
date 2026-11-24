using image_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace image_api.Services.Interfaces
{
    /// <summary>
    /// todo
    /// </summary>
    public interface IImageUploadService
    {
        public Task<Image> ImageUploadAsync(IFormFile file);
    }
}
