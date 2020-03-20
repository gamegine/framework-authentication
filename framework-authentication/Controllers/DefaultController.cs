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
        private readonly framework_authenticationContext _context;

        public DefaultController(framework_authenticationContext context)
        {
            _context = context;
        }

        // GET: Default
        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet("/login")]
        public ActionResult Login() => View();

        [HttpGet("/signup")]
        public ActionResult SignUp() => View();

        // POST: Login/Create
        [HttpPost("/")]
        [ValidateAntiForgeryToken]
        public ActionResult Connect()
        {
            Console.WriteLine("bravo");
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> ConnectAsync(int email, string password)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
            var u = await _context.Users.Include(u => u.tokens).Where(u => u.id == email).FirstOrDefaultAsync();
            if (u == null)
                return NotFound();
            Token t = u.Login();
            if (t == null)
                return NotFound();
            await _context.SaveChangesAsync();
            // return view t
            Response.Cookies.Append("token", t.token);
            return View();
        }

        [HttpPost("signup")]
        public ActionResult Create(string email, string password, string confirm)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
            Console.WriteLine(confirm);
            return View();
        }
    }
   
}