using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext __context;
        public AccountController(DataContext _context)
        {
            __context = _context;
        }

        [HttpPost("register")] //use it if we want to add a new resource through our API endpoint
                         
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto) //return an action results
        {
            if (await UserExist(registerDto.Username)) return BadRequest("Username already taken");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            __context.Users.Add(user); //saying to Entity framework that we want to add this to our users collection
            await __context.SaveChangesAsync();

            return user;
        } 

        private async Task<bool>UserExist(string username)
        {
            return await __context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }



    }
}