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

        // GET: Default
        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet("/login")]
        public ActionResult Login(string redirectUrl = "http://www.google.com")
        {
            if(ReqLog)
                Console.WriteLine("get login");
            ViewData["redirectUrl"] = redirectUrl;
            TempData["redirectUrl"] = redirectUrl;
            return View();
        }

        [HttpGet("/signup")]
        public ActionResult SignUp(string redirectUrl = "http://www.test.com")
        {
            if (ReqLog)
                Console.WriteLine("get signup");
            TempData["redirectUrl"] = redirectUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(int email, string password)
        {
            if (ReqLog)
                Console.WriteLine("post login");
            string data = TempData["redirectUrl"] != null ? TempData["redirectUrl"] as string : "/";
            //find user
            var u = await _context.Users.Include(u => u.tokens).Where(u => u.id == email).FirstOrDefaultAsync();
            if (u == null)
                return NotFound();
            //login -> get token
            Token t = u.Login();
            if (t == null)
                return NotFound();  
            await _context.SaveChangesAsync();
            //cookie
            Uri myUri = new Uri(data);
            CookieOptions co = new CookieOptions() { Domain = myUri.Host };
            Response.Cookies.Append("token", t.token, co);
            //final redirect to app
            return Redirect(data);
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Signup(int email, string password, string confirm)
        {
            if (ReqLog)
                Console.WriteLine("post signup");
            string data = TempData["redirectUrl"] != null ? TempData["redirectUrl"] as string : "/";
            // new user & login -> token
            Users users = new Users() { tokens = new List<Token>() };
            Token t = users.Login();
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            //cookie
            Uri myUri = new Uri(data);
            CookieOptions co = new CookieOptions(){ Domain = myUri.Host };
            Response.Cookies.Append("token", t.token,co);
            //final redirect to app
            return Redirect(data);
        }
    }
}