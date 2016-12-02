namespace MakeEvent.Business.Models
{
    public class ImageDto
    {
        public int Id { get; set; }

        public string Name     { get; set; }
        public string MimeType { get; set; }
        public byte[] Content  { get; set; }
    }
}
