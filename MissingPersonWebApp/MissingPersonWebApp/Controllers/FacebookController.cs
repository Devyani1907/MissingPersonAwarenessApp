using FacebookLibrary.Controllers;
using Microsoft.AspNetCore.Mvc;
using MissingPersonWebApp.Logic;
using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
