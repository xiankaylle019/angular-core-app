using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; //Add this
using ClientAPI.BusinessTier.Contracts;
using ClientAPI.Shared.DTOs;
using ClientAPI.Shared.ViewModels;
using ClientAPI.DataAccessTier.Contracts.IRepositories;
using AutoMapper;

namespace ClientAPI.BusinessTier
{
    public class Registration : IRegistration
    {
        private readonly IServiceProvider _service;
        public Registration(IServiceProvider service)
        {
            _service = service;
        }
        public async Task<bool> IsExist(object obj)
        {
            string username = obj.ToString();
            //NOTE: Add this (using Microsoft.Extensions.DependencyInjection;) 
            var personRepo = _service.GetService<IPersonRepo>();

            var result = await personRepo.UserExist(username);

            return result;
        }

        public async Task<PersonDTO> Register(PersonVM person)
        {
            var personRepo = _service.GetService<IPersonRepo>();

            var user = Mapper.Map<Models.Person>(person);       

            var result = await personRepo.Register(user,person.Password);

            var personDTO = Mapper.Map<PersonDTO>(result);
            
            return personDTO;
        }
    }
}