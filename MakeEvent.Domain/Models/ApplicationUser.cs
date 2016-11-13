using System;
using System.ComponentModel.DataAnnotations;
using MakeEvent.Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeEvent.Domain.Models
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        private DateTime? _createdDate;

        object IEntity.Id
        {
            get { return this.Id; }
            set { Id = (string) value; }
        }

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
    }
}
