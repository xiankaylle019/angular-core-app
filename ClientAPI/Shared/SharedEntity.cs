using System;

namespace ClientAPI.Shared
{
    public abstract class SharedEntity
    {
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}