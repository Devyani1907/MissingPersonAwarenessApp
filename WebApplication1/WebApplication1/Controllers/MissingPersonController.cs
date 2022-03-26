using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Logic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MissingPersonController : Controller
    {
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
            },
            JsonRequestBehavior.AllowGet);
            //return Json(new { Data = missingPeopleList   }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddMissingPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMissingPerson(MissingPersonModel model)
        {
            try
            {
                ManageMissingPersonLogic logic = new ManageMissingPersonLogic();

                if (model.File.ContentLength > 0)
                {
                    model.ImageName = model.File.FileName;
                    model.ImagePath = @"~/Image/UploadedFiles";
                }
                
                bool IsSaved = logic.SaveMissingPersonDetail(model);

                if(IsSaved)
                {
                    SaveImage(model);
                }

                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult UpdateMissingPerson(int id)
        {
            ViewData["Id"] = id;

            return View();
        }

        public JsonResult GetMissingPersonDetailById(int id)
        {
            ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
            MissingPersonModel model = new MissingPersonModel();

            model = logic.GetMissingPersonDetailById(id);

            if (model.Id > 0)
                return Json(new { data = model}, JsonRequestBehavior.AllowGet);
            else
                return null;

        }

        public void SaveImage(MissingPersonModel model)
        {
            try
            {
                if (model.File.ContentLength> 0)
                {
                    string FileName = Path.GetFileName(model.File.FileName);
                    string FilePath = Path.Combine(Server.MapPath(model.ImagePath), FileName);
                    model.File.SaveAs(FilePath);
                }
            }
            catch (Exception ex)
            {
            }
        }


    }
}