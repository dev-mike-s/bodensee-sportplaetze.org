using dotnet_api.Interfaces;

namespace dotnet_api.Services;

internal sealed class ImageValidationService : IImageValidationService
{
    public string GetTest()
    {
        return "Test validation service";
    }
}