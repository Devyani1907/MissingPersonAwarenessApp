using FacebookLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookLibrary.Controllers
{
    public class FacebookUtilityController : Controller
    {
       public string PostImage(string pageAccessToken, string appId, string appSecret, string imagePath, string message)
       {
            FacebookLogic logic = new FacebookLogic();
            string facebbokPostId =  logic.PostImage(pageAccessToken, appId, appSecret, imagePath, message);
            return facebbokPostId;
       }
    }
}