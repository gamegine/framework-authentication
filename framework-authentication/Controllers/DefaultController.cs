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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users U)
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
    }

   
}