using image_api.Types;

namespace image_api.Models
{
    /// <summary>
    /// Image model class representing an image entity with properties for id, url, etc.
    /// </summary>
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; } = string.Empty;
        public bool IsUploaded { get; set; } = false;
        public DateTime UploadedAt { get; } = DateTime.UtcNow;
        public ImageStatus Status { get; set; } = ImageStatus.PendingReview;
        public long Filesize { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string SportFieldId { get; set; } = string.Empty;
    }
}
