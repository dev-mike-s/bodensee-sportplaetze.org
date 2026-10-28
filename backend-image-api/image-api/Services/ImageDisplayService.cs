using image_api.Model;
using image_api.Data;
using image_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace image_api.Services
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class ImageDisplayService : IImageDisplayService
    {
        Guid _serviceId;
        private readonly InMemoryDb _db;

        public ImageDisplayService(InMemoryDb db)
        {
            _db = db;
            _serviceId = Guid.NewGuid();
        }

        public string GetTest()
        {
            return "Test display service, this service instance has an ID of {_serviceId}";
        }
        public async Task<List<Image>> GetAllImagesAsync()
        {
            return null;
            //return await _db.GetAllImagesAsync();
        }
    }
}
