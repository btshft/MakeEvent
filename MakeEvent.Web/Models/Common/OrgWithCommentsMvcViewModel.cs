using MakeEvent.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeEvent.Web.Models.Common
{
    public class OrgWithCommentsMvcViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }

        public List<CommentMvcViewModel> Comments { get; set; }

        public CommentMvcViewModel Comment { get; set; }
    }
}