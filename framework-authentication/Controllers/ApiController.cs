using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using framework_authentication.Data;
using framework_authentication.Models;
using System.Net;

namespace framework_authentication.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly framework_authenticationContext _context;

        public ApiController(framework_authenticationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// verify token
        /// </summary>
        /// <param name="token">{token:"str token"}</param>
        /// <returns>bool token ok</returns>
        // POST: api/verify
        [HttpPost("verify")]
        public async Task<ActionResult<bool>> PostVerify(Token token)
        {
            Console.WriteLine("verify : " + token);
            var t = await _context.Token.Where(t => t.token == token.token).FirstOrDefaultAsync();
            if (t == null)
                return false;
            if (!token.IsValid())
                return false;
            return true;
        }

        // POST: api/logout
        /// <summary>
        /// logout user
        /// </summary>
        /// <param name="token">{token:"str token"}</param>
        /// <returns>bool logout fail / ok</returns>
        [HttpPost("logout")]
        public async Task<ActionResult<bool>> PostLogout(Token token)
        {
            Console.WriteLine("logout : " + token);
            var t = await _context.Token.Where(t => t.token == token.token).FirstOrDefaultAsync();
            if (t == null)
                return false;
            _context.Token.Remove(t);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
