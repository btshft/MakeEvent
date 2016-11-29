using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MakeEvent.Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain.Models
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        #region IEntity

        private DateTime? _createdDate;

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        #endregion

        public virtual Organization Organization { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
             = new List<Comment>();

        public virtual ICollection<Ticket> Tickets { get; set; }
            = new List<Ticket>();
    }
}
