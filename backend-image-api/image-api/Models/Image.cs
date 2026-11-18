using image_api.Types;

namespace image_api.Models
{
    /// <summary>
    /// Image model class representing an image entity with properties for id, url, etc.
    /// </summary>
    public class Image
    {
        public Guid Id { get; set; }

        public int SportFieldId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public ImageStatus Status { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
