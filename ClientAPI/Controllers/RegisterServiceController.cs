using System;
using System.Threading.Tasks;
using ClientAPI.BusinessTier.Contracts;
using ClientAPI.Core.Shared;
using ClientAPI.Models;
using ClientAPI.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]    
    public class RegisterServiceController : ControllerBase
    {
        private readonly IServiceProvider _service;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public RegisterServiceController(IServiceProvider service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] PersonVM personVM) {

            // Add this to enable .GetService using Microsoft.Extensions.DependencyInjection;
            var regService = _service.GetService<IRegistration>(); 

            personVM.Username = personVM.Username.ToLower();

            if (await regService.IsExist(personVM.Username))
                ModelState.AddModelError("Username", "Username already exist");

            if (!ModelState.IsValid)
                return BadRequest (ModelState); //retruns model state error

            
            var user = new ApplicationUser
            {
                UserName = personVM.Username, 
                Email = personVM.Username
            };

            var result = await _userManager.CreateAsync(user, personVM.Password);

            if (result.Succeeded)
            {
                personVM.IdentityId = user.Id;                

                var newUser = await regService.Register(personVM);

                var tokenString = new JWTGenerator().GenerateJWT(newUser,_configuration);

                await _signInManager.SignInAsync(user, false);

                return Ok(new { token = tokenString ,username = personVM.Username });

            }

            return BadRequest (result.Errors); 
         }

    }
}