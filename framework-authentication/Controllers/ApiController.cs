using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using framework_authentication.Data;
using framework_authentication.Models;

namespace framework_authentication.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        const bool ReqLog = true;
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
        public async Task<ActionResult<ApiMsg>> PostVerify(Token token)
        {
            if(ReqLog)
                Console.WriteLine("post verify : " + token.token);
            var t = await _context.Token.Where(t => t.token == token.token).FirstOrDefaultAsync();
            if (t == null)
                return NotFound(new ApiMsg() { data = false , status = 400,msg = "token not fount"});
            if (!token.IsValid())
                return NotFound(new ApiMsg() { data = false, status = 400, msg = "token not valid" });
            return Ok(new ApiMsg() { data = true, status = 200, msg = "token is ok" });
        }

        // POST: api/logout
        /// <summary>
        /// logout user
        /// </summary>
        /// <param name="token">{token:"str token"}</param>
        /// <returns>bool logout fail / ok</returns>
        [HttpPost("logout")]
        public async Task<ActionResult<ApiMsg>> PostLogout(Token token)
        {
            if (ReqLog)
                Console.WriteLine("logout : " + token.token);
            var t = await _context.Token.Where(t => t.token == token.token).FirstOrDefaultAsync();
            if (t == null)
                return NotFound(new ApiMsg() { data = false, status = 400, msg = "token not fount" });
            _context.Token.Remove(t);
            await _context.SaveChangesAsync();
            return Ok(new ApiMsg() { data = false, status = 200, msg = "logout success" });
        }
    }
}
