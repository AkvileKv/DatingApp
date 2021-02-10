using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
           var claims = new List<Claim> //adding claims
           {
               new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
           }

           var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); //create some credentials

           var tokenDescriptor = new SecurityTokenDescriptor { //describe who goes inside Token
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
           };

           var tokenHandler = new JwtSecurityTokenHandler(); //need token handler

           var token = tokenHandler.CreateToken(tokenDescriptor); // create a token

           return tokenHandler.WriteToken(token); // return the written token
        }
    }
}