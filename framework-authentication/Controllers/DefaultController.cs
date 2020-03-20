using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using framework_authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace framework_authentication.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Connect(string email, string password)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
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