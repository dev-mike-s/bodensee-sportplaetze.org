using image_api.Model;
using image_api.Data;
using image_api.Services.Interfaces;

namespace image_api.Services;

/// <summary>
/// 
/// </summary>
internal sealed class ImageUploadService : IImageUploadService
{
    Guid _serviceId;
    private readonly InMemoryDb _db;

    public ImageUploadService(InMemoryDb inMemoryDb)
    {
        _db = inMemoryDb;
        _serviceId = Guid.NewGuid();
    }

    public async Task<Image> UploadImageAsync(Image image)
    {
        _db.Images.Add(image);
        await _db.SaveChangesAsync();
        return image;
    }

    public string GetTest()
    {
        return "Test upload service";
    }
}
