using dotnet_api.Models;
using dotnet_api.Data;
using dotnet_api.Services.Interfaces;

namespace dotnet_api.Services;
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
        return await _db.GetAllImagesAsync();
    }
}