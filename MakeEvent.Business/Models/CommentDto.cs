using System;

namespace MakeEvent.Business.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string OrganizationId { get; set; }

        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public decimal? Mark { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
