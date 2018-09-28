using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ClientAPI.Core.Shared.Mapping.Contracts;
using ClientAPI.Models;
using Core.Shared.Mapping;

namespace ClientAPI.Shared.ViewModels
{
    public class PersonVM : BaseEntityVM, ICustomMapping
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage= "You must specify a password with a minimum of 4 characters" )]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name minimum length is 2")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name minimum length is 2")]
        public string LastName { get; set; }        
        public string IdentityId { get; set; }
        public void CreateMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PersonVM, Person>();       

            cfg.IgnoreUnmapped();
        }
    }
}