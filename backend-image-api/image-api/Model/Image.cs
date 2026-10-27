
namespace image_api.Model
{
    /// <summary>
    /// Image properties: 
    /// </summary>
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public bool IsValidated { get; set; } = false;
        public bool IsUploaded { get; set; } = false;
        public bool IsDisplayed { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string SportFieldId { get; set; }
        public int Filesize { get; set; }
    }
}
