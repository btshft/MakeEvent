using System;

namespace MakeEvent.Web.Models.Admin
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}