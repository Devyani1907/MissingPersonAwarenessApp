using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacebookUtility;
using MissingPersonWebApp.Data;
using MissingPersonWebApp.Models;
using FacebookLibrary.Controllers;
using FacebookLibrary.Logic;

namespace MissingPersonWebApp.Logic
{
    public class FacebookLogic
    {
        public string CreateFacebookMessage(MissingPersonModel model)
        {

            try
            {
                ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
                int Age = logic.CalculateAge(model.DateOfBirth);
                string message = "On " + model.MissingDate.ToShortDateString() + ", one person was registered as missing person. Below are the details:" + Environment.NewLine +
                        "Name: " + model.FirstName + " " + model.LastName + Environment.NewLine +
                        "Age: " + Age;
                return message;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        public FacebookModel GetFacebookAccountDetail()
        {
            try
            {
                FacebookModel model = new FacebookModel();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    model = (from x in entities.FacebookAccounts
                             where x.Enable == true
                             select new FacebookModel
                             {

                                 AppId = x.AppId,
                                 AppName = x.AppName,
                                 AppSecret = x.AppSecret,
                                 PageAccessToken = x.PageAccessToken,
                                 FacebookAccountId = x.FacebookAccountId,
                                 Enable = x.Enable

                             }).FirstOrDefault();

                }

                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

        public List<FacebookModel> GetAllFacebookAccountDetail()
        {
            try
            {
                List<FacebookModel> model = new List<FacebookModel>();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    model = (from x in entities.FacebookAccounts
                             select new FacebookModel
                             {

                                 AppId = x.AppId,
                                 AppName = x.AppName,
                                 AppSecret = x.AppSecret,
                                 PageAccessToken = x.PageAccessToken,
                                 FacebookAccountId = x.FacebookAccountId,
                                 Enable = x.Enable

                             }).ToList();

                }

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void AddFacebookAccount(FacebookModel model)
        {
            try
            {
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    var detail = new FacebookAccount();

                    detail.AppId = model.AppId;
                    detail.AppName = model.AppName;
                    detail.AppSecret = model.AppSecret;
                    detail.PageAccessToken = model.PageAccessToken;
                    detail.Enable = model.Enable;

                    entities.FacebookAccounts.Add(detail);
                    entities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
            }

        }
        public void UpdateFacebookAccount(FacebookModel model)
        {
            try
            {
                var detail = new FacebookAccount();
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    detail = (from x in entities.FacebookAccounts
                              where x.FacebookAccountId == model.FacebookAccountId
                              select x).FirstOrDefault();

                    detail.AppId = model.AppId;
                    detail.AppName = model.AppName;
                    detail.AppSecret = model.AppSecret;
                    detail.PageAccessToken = model.PageAccessToken;
                    detail.Enable = model.Enable;

                    entities.FacebookAccounts.Update(detail);
                    entities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
            }

        }

        public FacebookModel GetFacebookAccountById(int id)
        {
            try
            {
                FacebookModel model = new FacebookModel();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    model = (from x in entities.FacebookAccounts
                             where x.FacebookAccountId == id
                             select new FacebookModel
                             {
                                 AppId = x.AppId,
                                 AppName = x.AppName,
                                 AppSecret = x.AppSecret,
                                 PageAccessToken = x.PageAccessToken,
                                 FacebookAccountId = x.FacebookAccountId,
                                 Enable = x.Enable

                             }).FirstOrDefault();

                }

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
