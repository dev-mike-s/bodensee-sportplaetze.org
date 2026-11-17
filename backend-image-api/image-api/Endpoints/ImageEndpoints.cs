using image_api.Data;
using image_api.Services.Interfaces;

namespace image_api.Endpoints
{
    public static class ImageEndpoints
    {
        public static void Map(WebApplication app)
        {

            app.MapGet("/images", async (IImageDisplayService imageDisplayService) =>
            {
                var images = imageDisplayService.GetImages();
                return Results.Ok(images);
            });

            app.MapGet("/images/{id}", async (int id, IImageDisplayService imageDisplayService) =>
            {
                var image = imageDisplayService.GetImageById(id);
                return Results.Ok();
            });
        }
    }
}