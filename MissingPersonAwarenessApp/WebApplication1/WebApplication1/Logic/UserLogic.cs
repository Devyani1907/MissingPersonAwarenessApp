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
            UserModel userModel = new UserModel();

            using (MissingPersonEntities entities = new MissingPersonEntities())
            {

                // Get User by Email
                var userDetail = from user in entities.Users
                                 where user.Email == model.Email
                                 select new UserModel
                                 {
                                     Email = user.Email,
                                     Password = user.Password
                                 };
            }
            return userModel;
        }
    }
}