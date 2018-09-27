using System;

namespace ClientAPI.Shared.DTOs
{
    public abstract class BaseEntityDTO : SharedEntity
    {
        public DateTime CreatedOn { get; set; }
    }
}