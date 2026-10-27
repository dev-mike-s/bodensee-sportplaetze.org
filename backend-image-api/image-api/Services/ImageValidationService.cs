
using image_api.Services.Interfaces;

namespace image_api.Services;

/// <summary>
/// 
/// </summary>
internal sealed class ImageValidationService : IImageValidationService
{
    public string GetTest()
    {
        return "Test validation service";
    }
}