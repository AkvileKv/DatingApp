using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
                         //return an action results
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            __context.Users.Add(user); //saying to Entity framework that we want to add this to our users collection
            await __context.SaveChangesAsync();

            return user;
        } 



    }
}