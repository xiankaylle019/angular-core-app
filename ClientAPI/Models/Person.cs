using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClientAPI.Models
{
    public class Person : BaseEntity
    {     
        public int PersonId { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsProfileUpdated { get; set; }
        public virtual ICollection<Goals> Goals { get; set; }
        public virtual Contacts Contacts { get; set; }
    }
}