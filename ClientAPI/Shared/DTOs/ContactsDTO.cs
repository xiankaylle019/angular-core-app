using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;

namespace ClientAPI.Shared.DTOs
{
    public class ContactsDTO : BaseEntityDTO, IMapSource<Contacts>
    {
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
    }
}