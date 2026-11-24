using image_api.Models;
using image_api.Data;
using image_api.Types;
using image_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public async Task<Image> ImageUploadAsync(IFormFile file)
    {
        var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","uploads");
        Directory.CreateDirectory(uploadsDir);
        var storedName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsDir, storedName);
        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);
        
        var image = new Image
        {
            Id = Guid.NewGuid(),
            FileName = storedName,
            Status = ImageStatus.PendingReview,
            UploadedAt = DateTime.UtcNow
        };
        await _db.AddImageAsync(image);
        return image;
    }

    /// <summary>
    /// todo check if obsolete.
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