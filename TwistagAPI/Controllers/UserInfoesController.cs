using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwistagAPI.Models;

namespace TwistagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly TwistagContext _context;

        public UserInfoesController(TwistagContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInformation>>> GetUserInfos()
        {
            return await _context.UserInformations.ToListAsync();
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInformation>> GetUserInfo(int id)
        {
            var userInfo = await _context.UserInformations.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/UserInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInformation userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUserInfo(UserInformation userInfo)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var statusCode = HttpStatusCode.OK;
            var message = "User added successfully!";

            UserInformation? user = await _context.UserInformations.Where(x => x.Email == userInfo.Email).FirstOrDefaultAsync();

            if(user == null)
            {
               
                _context.UserInformations.Add(userInfo);
            }
            else
            {
                statusCode= HttpStatusCode.Conflict;
                message = "There is already a user registered with that email";

            }
           
            await _context.SaveChangesAsync();

            return StatusCode((int)statusCode, message);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            var userInfo = await _context.UserInformations.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInformations.Remove(userInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInformations.Any(e => e.Id == id);
        }
    }
}
