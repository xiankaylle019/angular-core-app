using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ClientAPI.BusinessTier.Contracts;
using ClientAPI.DataAccessTier.Contracts.IRepositories;
using ClientAPI.Shared.DTOs;
using ClientAPI.Shared.ViewModels;

namespace ClientAPI.BusinessTier
{
    public class Auth : IAuth
    {
        private readonly IServiceProvider _service;
        public Auth(IServiceProvider service)
        {
            _service = service;
        }
        public async Task<PersonDTO> Login(AuthVM auth)
        {
            var personRepo = _service.GetService<IPersonRepo>();
        
            var user = await personRepo.Login(auth.Username, auth.Password);

            var personDTO = Mapper.Map<PersonDTO>(user);
           
            return personDTO;
        }
    }
}