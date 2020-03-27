using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using framework_authentication.Data;
using framework_authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace framework_authentication.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
        const bool ReqLog = true;
        private readonly framework_authenticationContext _context;
        public DefaultController(framework_authenticationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get index page
        /// </summary>
        /// <returns>view index</returns>
        // GET: Default
        [HttpGet]
        public ActionResult Index() => View();

        /// <summary>
        /// get login page form
        /// </summary>
        /// <param name="redirectUrl">url de redrection apres conexion</param>
        /// <returns>view login</returns>
        [HttpGet("/login")]
        public ActionResult Login(string redirectUrl = "http://www.google.com")
        {
            if(ReqLog)
                Console.WriteLine("get login");
            ViewData["redirectUrl"] = redirectUrl;
            TempData["redirectUrl"] = redirectUrl;
            return View();
        }

        /// <summary>
        /// inscription de l utilisateur
        /// </summary>
        /// <param name="redirectUrl">url de redrection apres inscription</param>
        /// <returns>view signup</returns>
        [HttpGet("/signup")]
        public ActionResult SignUp(string redirectUrl = "http://www.test.com")
        {
            if (ReqLog)
                Console.WriteLine("get signup");
            TempData["redirectUrl"] = redirectUrl;
            return View();
        }

        /// <summary>
        /// post action login
        /// connect l utilisateur
        /// </summary>
        /// <param name="email">identifiant de l utilisateur</param>
        /// <param name="password"></param>
        /// <returns>redirection ver la page <paramref name="redirectUrl"/> du formulaire </returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (ReqLog)
                Console.WriteLine("post login");
            //find user
            var u = await _context.Users.Include(u => u.tokens).Where(u => u.email == email).FirstOrDefaultAsync();
            if (u == null)
                return NotFound();
            //login -> get token
            Token t = u.Login<Token>();
            if (t == null)
                return NotFound();  
            await _context.SaveChangesAsync();
            //cookie
            Response.Cookies.Append("token", t.token);
            string data = TempData["redirectUrl"] != null ? TempData["redirectUrl"] as string : "/";
            data += "?token=" + t.token; //cookie fail ?
            Uri myUri = new Uri(data);
            CookieOptions co = new CookieOptions() { Domain = myUri.Host };
            Response.Cookies.Append("token", t.token, co);
            //final redirect to app
            return Redirect(data);
        }

        /// <summary>
        /// post action signup
        /// cree un utilisateur et le connect
        /// </summary>
        /// <param name="email">identifiant de l utilisateur</param>
        /// <param name="password"></param>
        /// <param name="confirm"></param>
        /// <returns>redirection ver la page <paramref name="redirectUrl"/> du formulaire </returns>
        [HttpPost("signup")]
        public async Task<ActionResult> Signup(string email, string password, string confirm)
        {
            if (ReqLog)
                Console.WriteLine("post signup");
            // new user & login -> token
            UsersByEmail users = new UsersByEmail() { tokens = new List<Token>(), email = email };
            Token t = users.Login<Token>();
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            //cookie
            Response.Cookies.Append("token", t.token);
            string data = TempData["redirectUrl"] != null ? TempData["redirectUrl"] as string : "/";
            data += "?token=" + t.token; //cookie fail ?
            Uri myUri = new Uri(data);
            CookieOptions co = new CookieOptions(){ Domain = myUri.Host };
            Response.Cookies.Append("token", t.token,co);
            //final redirect to app
            return Redirect(data);
        }
    }
}