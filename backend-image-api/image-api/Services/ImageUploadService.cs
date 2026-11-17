using image_api.Models;
using image_api.Data;
using image_api.Services.Interfaces;

namespace image_api.Services;

/// <summary>
/// 
/// </summary>
internal sealed class ImageUploadService : IImageUploadService
{
    #region --- PROPERTIES --- 

    Guid _serviceId;
    private readonly InMemoryDb _db;

    #endregion
    #region --- CONSTRUCTOR ---

    public ImageUploadService(InMemoryDb inMemoryDb)
    {
        _db = inMemoryDb;
        _serviceId = Guid.NewGuid();
    }

    #endregion
    #region --- PUBLIC METHODS ---

    public string GetTest()
    {
        return "Test upload service";
    }

    public async Task<Image> UploadImageAsync(Image image)
    {
        _db.Images.Add(image);
        await _db.SaveChangesAsync();
        return image;
    }

    /// <summary>
    /// Create Image returns img from db.
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public async Task<Image> CreateImage(Image image)
    {
        Image img = await _db.AddImageAsync(image);
        return img;
    }

    #endregion
    #region --- PRIVATE METHODS ---
    #endregion
}