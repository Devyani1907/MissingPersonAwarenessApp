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
                    message = "Correct";
                }
            }

            return View(Json(new { Data = message}, JsonRequestBehavior.AllowGet));
        }

        public ActionResult Registration()
        {
            return View();
        }

    }
}