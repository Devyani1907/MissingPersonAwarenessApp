using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using MissingPersonWebApp.Logic;
using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;


namespace MissingPersonWebApp.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: User
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set("Role", JsonSerializer.SerializeToUtf8Bytes("admin"));

                UserLogic userLogic = new UserLogic();
                UserModel userModel = userLogic.ValidUser(model);

                byte[] salt = new byte[128 / 8];

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: model.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                if (userModel.Email != null && userModel.Password == hashed)
                {
                    HttpContext.Session.Set("role", System.Text.Json.JsonSerializer.SerializeToUtf8Bytes("admin"));
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ViewBag.Message = "Invalid email or password";
                    return View();
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                UserLogic userLogic = new UserLogic();
                // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
                byte[] salt = new byte[128 / 8];
                
                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: model.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                model.Password = hashed;
                userLogic.CreateUser(model);

                return Redirect("Login");
            }
            return View(model);
        }

       
    }
}
