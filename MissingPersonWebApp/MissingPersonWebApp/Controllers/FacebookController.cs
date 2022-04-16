using FacebookLibrary.Controllers;
using Microsoft.AspNetCore.Mvc;
using MissingPersonWebApp.Logic;
using MissingPersonWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Controllers
{
    public class FacebookController : Controller
    {
        public void PostImage(MissingPersonModel model)
        {
            ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
            FacebookLogic facebookLogic = new FacebookLogic();
            FacebookModel facebookModel = new FacebookModel();
            FacebookUtilityController utility = new FacebookUtilityController();

            model.FacebookText = facebookLogic.CreateFacebookMessage(model);
            string path = model.ImagePath + model.ImageName;

            facebookModel = facebookLogic.GetFacebookAccountDetail();
            model.FacebookPostId  = utility.PostImage(facebookModel.PageAccessToken, facebookModel.AppId, facebookModel.AppSecret, path, model.FacebookText);

            model.FacebookAccountId = facebookModel.FacebookAccountId;
            logic.UpdateFacebookPostId(model);
        }

        public ActionResult FacebookDashboard()
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

        public ActionResult GetFacebookAccounts()
        {
            List<FacebookModel> List = new List<FacebookModel>();
            FacebookLogic Logic = new FacebookLogic();
            List = Logic.GetAllFacebookAccountDetail();

            return Json(new
            {
                draw = 1,
                recordsTotal = List.Count(),
                recordsFiltered = List.Count(),
                data = List
            });
        }

        public ActionResult AddFacebookAccount()
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

        [HttpPost]
        public ActionResult AddFacebookAccount(FacebookModel model)
        {
            if (ModelState.IsValid)
            {
                FacebookLogic logic = new FacebookLogic();
                logic.AddFacebookAccount(model);
                return Redirect("FacebookDashboard");
            }

            return View(model);
        }


        public ActionResult UpdateFacebookAccount(int id)
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
            ViewData["Id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateFacebookAccount(FacebookModel model)
        {
            if (ModelState.IsValid)
            {
                FacebookLogic logic = new FacebookLogic();
                logic.UpdateFacebookAccount(model);
                return Redirect("FacebookDashboard");
            }

            return View(model);
        }

        public JsonResult GetFacebookAccountById(int id)
        {
            FacebookLogic logic = new FacebookLogic();
            FacebookModel model = new FacebookModel();

            model = logic.GetFacebookAccountById(id);

            if (model.FacebookAccountId > 0)
                return Json(new { data = model });
            else
                return null;

        }
    }
}
