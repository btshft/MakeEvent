using System;
using MakeEvent.Web.Attributes;

namespace MakeEvent.Web.Models.Admin
{
    public class CommentMvcViewModel
    {
        public int Id { get; set; }
        public string OrganizationId { get; set; }

        [LocalizedDisplay("CommentText", typeof(App_LocalResources.Localization))]
        public string Text        { get; set; }

        [LocalizedDisplay("CommentAuthorName", typeof(App_LocalResources.Localization))]
        public string AuthorName  { get; set; }

        [LocalizedDisplay("CommentAuthorEmail", typeof(App_LocalResources.Localization))]
        public string AuthorEmail { get; set; }

        [LocalizedDisplay("CommentDate", typeof(App_LocalResources.Localization))]
        public DateTime CreatedDate { get; set; }
    }
}