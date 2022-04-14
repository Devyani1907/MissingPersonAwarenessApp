using Microsoft.AspNetCore.Mvc;
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
            HttpContext.Session.Set("Role", JsonSerializer.SerializeToUtf8Bytes("admin"));
            
            bool isSessionExist = HttpContext.Session.IsAvailable;
            if (isSessionExist)
            {
                HttpContext.Session.TryGetValue("Role", out byte[] value);
                string role = Encoding.ASCII.GetString(value).Replace("\\\"", "");
                if(role == "admin")
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
    }
}
