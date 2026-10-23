using dotnet_api.Data;
using dotnet_api.Interfaces;
using dotnet_api.Models;

namespace dotnet_api.Services;

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
