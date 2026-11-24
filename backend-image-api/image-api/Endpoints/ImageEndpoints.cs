using image_api.Data;
using image_api.Services.Interfaces;

namespace image_api.Endpoints
{
    public static class ImageEndpoints
    {
        public static void Map(WebApplication app)
        {
            /// <summary>
            /// Endpoint to upload an image.
            /// </summary>
            app.MapPost("/api/images/upload", async (IFormFile file, IImageUploadService imageUploadService) =>
            {
                if (file is null || file.Length == 0)
                {
                    return Results.BadRequest("Keine Datei erhalten.");
                }
                var image = await imageUploadService.ImageUploadAsync(file);
                
                return Results.Created($"/api/images/{image.Id}", image); //201
            });
        
            /// <summary>
            /// todo
            /// </summary>
            app.MapGet("/images", async (IImageDisplayService imageDisplayService) =>
            {
                var images = imageDisplayService.GetImages();
                return Results.Ok(images);
            });

            /// <summary>
            /// todo
            /// </summary>
            app.MapGet("/api/images/{id}", async (int id, IImageDisplayService imageDisplayService) =>
            {
                var image = imageDisplayService.GetImageById(id);
                return Results.Ok();
            });

        }
    }
}