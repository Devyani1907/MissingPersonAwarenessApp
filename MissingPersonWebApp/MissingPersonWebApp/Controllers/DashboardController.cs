using Microsoft.AspNetCore.Mvc;
using MissingPersonWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            bool isSessionExist = HttpContext.Session.IsAvailable;
            if (isSessionExist)
            {
                HttpContext.Session.TryGetValue("role", out byte[] value);
                string role = string.Empty;
                if (value != null)
                {
                    role = Encoding.ASCII.GetString(value).Replace(@"\", "");
                    role = JsonConvert.DeserializeObject<string>(role);

                }
                if (role == "admin")
                {
                    ViewData["role"] = "admin";
                }
                else
                {
                    ViewData["role"] = "user";
                }
            }
           
            return View();
        }

        [HttpGet]
        public IActionResult Contactus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactus(ContactusModel model)
        { 
            if(ModelState.IsValid)
            {


            }
            
            return View(model);
        }
    }
}
