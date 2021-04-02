using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        //Methods that are going to return various kinds of responses that are not successful (errors)
        [Authorize]
        [HttpGet("auth")] // going to API, buggie and then auth
        public ActionResult<string> GetSecret() // test 401 unauthorised responses
        {
         return "Secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound() //404
        {
            var thing = _context.Users.Find(-1); // looking for an unexisting thing (users with id = 1)

            if (thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("server-error")] //500
        public ActionResult<string> GetServerError()
        {

             var thing = _context.Users.Find(-1);

             var thingToReturn = thing.ToString();

             return thingToReturn;         

        }

        [HttpGet("bad-request")] //400
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }

    }
}