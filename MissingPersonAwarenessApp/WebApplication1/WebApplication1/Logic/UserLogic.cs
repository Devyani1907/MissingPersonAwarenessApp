using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Logic
{
    public class UserLogic
    {
        public UserModel ValidUser(UserModel model)
        {
            try
            {
                UserModel userModel = new UserModel();

                using (MissingPersonEntities entities = new MissingPersonEntities())
                {
                    var userDetail = new User();

                    // Get User by Email
                    userDetail = (from user in entities.Users
                                  where user.Email == model.Email
                                  select user).FirstOrDefault<User>();

                    userModel.Email = userDetail.Email;
                    userModel.Password = userDetail.Password;

                }
                return userModel;
            }
            catch (Exception ex)
            { 
                
            }

            return null;
        }

        public void CreateUser(UserModel model)
        {
            try
            {
                using (MissingPersonEntities entities = new MissingPersonEntities())
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
            catch(Exception ex)
            { 
            
            }
            
        }
    }
}