
namespace dotnet_api.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsValidated { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SportFieldId { get; set; }
        public int Filesize { get; set; }
    }
}
