using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using framework_authentication.Data;
using framework_authentication.Models;

namespace framework_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly framework_authenticationContext _context;

        public UsersController(framework_authenticationContext context)
        {
            _context = context;
        }

        // GET: api/Users/reset
        [HttpGet("reset")]
        public async Task<ActionResult<IEnumerable<Users>>> ResetUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.Token.RemoveRange(_context.Token);
            for (int i = 0; i < 3; i++)
            {
                UsersByPassword users = new UsersByPassword() { email = "email"+i};
                users.SetPassword("p"+i);
                users.tokens = new List<Token> { new Token() };
                _context.Users.Add(users);
            }
            await _context.SaveChangesAsync();
            return _context.Users;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.Include(u=>u.tokens).ToListAsync();
        }
        // GET: api/users/token
        [HttpGet("token")]
        public async Task<ActionResult<IEnumerable<Token>>> GetToken()
        {
            return await _context.Token.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.Include(u => u.tokens).FirstOrDefaultAsync(u => u.id == id);
            if (users == null)
                return NotFound();
            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, UsersByEmail users)
        {
            if (id != users.id)
                return BadRequest();
            _context.Entry(users).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(UsersByPassword users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsers", new { id = users.id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
                return NotFound();
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
