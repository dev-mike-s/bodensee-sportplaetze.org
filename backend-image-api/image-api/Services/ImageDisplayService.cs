using image_api.Models;
using image_api.Data;
using image_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace image_api.Services
{
    /// <summary>
    /// Implements the IImageDisplayService interface to provide CRUD operations for image display.
    /// Interacts with the Db to perform operations on image data.
    /// </summary>
    internal sealed class ImageDisplayService : IImageDisplayService
    {
        #region --- PROPERTIES ---

        Guid _serviceId;
        private readonly InMemoryDb _db;

        #endregion
        #region --- CONSTRUCTOR ---

        public ImageDisplayService(InMemoryDb db)
        {
            _db = db;
            _serviceId = Guid.NewGuid();
        }

        #endregion
        #region --- PUBLIC METHODS ---

        public string GetTest()
        {
            return "Test display service, this service instance has an ID of {_serviceId}";
        }

        /// <summary>
        /// Gets all images as an IEnumerable from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Image>> GetImages()
        {
            return await _db.GetAllImagesAsync();
        }

        /// <summary>
        /// Gets an image by its ID from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Image> GetImageById(int id) 
        {
            return null;
        }

        #endregion
        #region --- PRIVATE METHODS ---
        #endregion
    }
}