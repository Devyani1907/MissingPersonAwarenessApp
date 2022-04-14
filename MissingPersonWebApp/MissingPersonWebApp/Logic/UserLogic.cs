using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MissingPersonWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace MissingPersonWebApp.Logic
{
    public class UserLogic
    {
        public UserModel ValidUser(UserModel model)
        {
            try
            {
                
                    UserModel userModel = new UserModel();

                    using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                    {
                        var userDetail = new User();

                        // Get User by Email
                        userDetail = (from user in entities.Users
                                      where user.Email == model.Email
                                      select user).FirstOrDefault<User>();

                        if(userDetail != null && userDetail.Email != null)
                        {
                            userModel.Email = userDetail.Email;
                            userModel.Password = userDetail.Password;
                        }
                    }
                return userModel;
                
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public void CreateUser(RegistrationModel model)
        {
            try
            {
                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    User userDetail = new User();

                    userDetail.Email = model.Email;
                    userDetail.Password = model.Password;
                    userDetail.Username = model.Username;
                    userDetail.CreatedTime = DateTime.Now;

                    entities.Users.Add(userDetail);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
