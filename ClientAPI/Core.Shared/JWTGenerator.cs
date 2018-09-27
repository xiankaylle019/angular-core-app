using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ClientAPI.Shared.DTOs;
using Microsoft.Extensions.Configuration;

namespace ClientAPI.Core.Shared
{
    public class JWTGenerator
    {
        public object GenerateJWT(PersonDTO person, IConfiguration config){

            var claims = GetClaims(person.Username);

            var jwtkey = config["Jwt:Key"];

            var issuer = config["Jwt:JwtIssuer"];

            var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes (jwtkey));

            var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires : DateTime.Now.AddMinutes (30),
                signingCredentials : creds);

            var tokenString = new JwtSecurityTokenHandler ().WriteToken(token);

            return tokenString;
        }

        private Claim[] GetClaims(string username){

            var claims = new [] {
                new Claim (JwtRegisteredClaimNames.Sub, username),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
            };

            return claims;
        }
    }
}