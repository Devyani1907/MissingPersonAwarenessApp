using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MissingPersonWebApp.Logic;
using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MissingPersonWebApp.Controllers;
using FacebookUtility;

namespace MissingPersonWebApp.Controllers
{
   
    public class MissingPersonController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public MissingPersonController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: MissingPerson Details
        public ActionResult ManageMissingPerson()
        {
            return View();
        }


        public ActionResult GetMissingPeopleDetail()
        {
            List<MissingPersonModel> missingPeopleList = new List<MissingPersonModel>();
            ManageMissingPersonLogic missingPersonLogic = new ManageMissingPersonLogic();
            missingPeopleList = missingPersonLogic.GetMissingPeopleDetail();

            return Json(new
            {
                draw = 1,
                recordsTotal = missingPeopleList.Count(),
                recordsFiltered = missingPeopleList.Count(),
                data = missingPeopleList
            });
        }

        public ActionResult AddMissingPerson()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public ActionResult AddMissingPerson(MissingPersonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
                    model.ImageName = UploadedFile(model);
                    model.ImagePath = _hostingEnvironment.WebRootPath + @"\\Image\\MissingPeopleImages\\";

                    model.Id = logic.SaveMissingPersonDetail(model);

                    if(model.Id > 0 && model.PublishonTwitter)
                    {
                        TwitterController twitter = new TwitterController();
                        var result = Task.Run(async () =>
                        {
                            await twitter.PostImage(model);
                        });
                    }

                    if (model.Id > 0 && model.PublishonFacebook)
                    {
                        FacebookController facebook = new FacebookController();
                        facebook.PostImage(model);
                    }

                    return Redirect("ManageMissingPerson");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "";
                return View();
            }
        }

        public ActionResult UpdateMissingPerson(int id)
        {
            ViewData["Id"] = id;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateMissingPerson(MissingPersonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
                    bool isUpdated = logic.UpdateMissingPersonDetail(model);

                    MissingPersonModel personData = new MissingPersonModel();
                    personData = logic.GetMissingPersonDetailById(model.Id);

                    if (personData.TwitterPostId == null && model.PublishonTwitter)
                    {
                        TwitterController twitter = new TwitterController();
                        var result = Task.Run(async () =>
                        {
                            await twitter.PostImage(model);
                        });
                    }


                    if (personData.FacebookPostId == null && model.PublishonFacebook)
                    {
                        FacebookController facebook = new FacebookController();
                        facebook.PostImage(model);
                    }


                    return Redirect("ManageMissingPerson");
                }
                ViewData["Id"] = model.Id;
                return View(model);
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        public ActionResult DeleteMissingPerson(int id)
        {
            ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
            bool isDeleted = logic.DeleteMissingPerson(id);
            return Json(new { data = isDeleted });
        }


        public JsonResult GetMissingPersonDetailById(int id)
        {
            ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
            MissingPersonModel model = new MissingPersonModel();

            model = logic.GetMissingPersonDetailById(id);

            if (model.Id > 0)
                return Json(new { data = model });
            else
                return null;

        }


        private string UploadedFile(MissingPersonModel model)
        {
            string uniqueFileName = null;

            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Image/MissingPeopleImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.File.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
