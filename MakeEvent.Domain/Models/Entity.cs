using System;
using System.ComponentModel.DataAnnotations;
using MakeEvent.Domain.Interfaces;

namespace MakeEvent.Domain.Models
{
    public abstract class Entity : IEntity
    {
        private DateTime? _createdDate;

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string Key        { get; set; }
        public string CreatedBy  { get; set; }
        public string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
