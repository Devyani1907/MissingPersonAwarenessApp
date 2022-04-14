using MissingPersonWebApp.Data;
using MissingPersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Logic
{
    public class TwitterLogic
    {
       
        public TwitterModel GetTwitterAccountDetail()
        {
            try
            {
                TwitterModel twitterObj = new TwitterModel();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    twitterObj = (from x in entities.TwitterAccounts
                                  where x.Enable == true
                                  select new TwitterModel
                                  {
                                      TwitterAccountId = x.TwitterAccountId,
                                      ConsumerKey = x.ConsumerKey,
                                      ConsumerSecret = x.ConsumerSecret,
                                      AccessToken = x.AccessToken,
                                      AccessTokenSecret = x.AccessTokenSecret,
                                      Enable = x.Enable

                                  }).FirstOrDefault();
                }

                return twitterObj;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
    }
}
