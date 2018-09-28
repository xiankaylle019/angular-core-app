using AutoMapper;
using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;
using ClientAPI.Shared.DTOs;
using Core.Shared.Mapping;

namespace ClientAPI.Shared.DTOs
{
    public class PersonDTO  :  BaseEntityDTO, ICustomMapping
    {
        public int PersonId { get; set; }        
        public string Username { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsProfileUpdated { get; set; }
        public string FullName { get => $"{ this.FirstName } { this.LastName }";}
        public ContactsDTO ContactsDTO { get; set; }
        public GoalsDTO GoalsDTO { get; set; }
        
        public void CreateMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Person, PersonDTO>()
            .ForMember(d => d.ContactsDTO, opt => opt.MapFrom(s => s.Contacts))
            .ForMember(d => d.GoalsDTO, opt => opt.MapFrom(s => s.Goals));

            cfg.IgnoreUnmapped();
        }
    }
}