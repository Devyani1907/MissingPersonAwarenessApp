using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Logic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            UserLogic userLogic = new UserLogic();
            UserModel userModel = userLogic.ValidUser(model);
            string message = string.Empty;

            if (userModel.Email == null)
            {
                message = "Incorrect email or password";
            }
            else
            {
                if (model.Password == userModel.Password)
                {
                    ViewData["IsAdmin"] = "Yes";
                    return RedirectToAction("Dashboard", "Dashboard");
                }
            }


            return View(Json(new { Data = message}, JsonRequestBehavior.AllowGet));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(UserModel model)
        {
            UserLogic userLogic = new UserLogic();
            userLogic.CreateUser(model);

            return View("Login");
        }


        

    }
}