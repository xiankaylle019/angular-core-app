using System;

namespace ClientAPI.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}