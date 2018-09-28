using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;

namespace ClientAPI.Shared.ViewModels
{
    public class ContactsVM : BaseEntityVM, IMapDestination<Contacts> 
    {
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }

    }
}