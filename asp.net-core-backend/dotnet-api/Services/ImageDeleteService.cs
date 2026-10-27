using dotnet_api.Services.Interfaces;

namespace dotnet_api.Services;

internal sealed class ImageDeleteService : IImageDeleteService
{
    public string GetTest()
    {
        return "Test delete service";
    }
}