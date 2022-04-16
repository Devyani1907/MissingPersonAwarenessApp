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

        public List<TwitterModel> GetAllTwitterAccountDetail()
        {
            List<TwitterModel> twitters = new List<TwitterModel>();
            using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
            {
                twitters = (from x in entities.TwitterAccounts
                            select new TwitterModel
                            {
                                AccessToken = x.AccessToken,
                                AccessTokenSecret = x.AccessTokenSecret,
                                ConsumerKey = x.ConsumerKey,
                                ConsumerSecret = x.ConsumerSecret,
                                Enable = x.Enable,
                                AppName = x.AppName,
                                TwitterAccountId = x.TwitterAccountId

                            }).ToList();
            }

            return twitters;
        }

        public void AddTwitterAccount(TwitterModel model)
        {
            using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
            {
                TwitterAccount twitter = new TwitterAccount();

                twitter.CreatedDatetime = DateTime.Now;
                twitter.AccessToken = model.AccessToken;
                twitter.AccessTokenSecret = model.AccessTokenSecret;
                twitter.AppName = model.AppName;
                twitter.ConsumerSecret = model.ConsumerSecret;
                twitter.ConsumerKey = model.ConsumerKey;
                twitter.Enable = model.Enable;

                entities.TwitterAccounts.Add(twitter);
                entities.SaveChanges();
            }

        }

        public void UpdateTwitterAccount(TwitterModel model)
        {
            using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
            {
                TwitterAccount twitter = new TwitterAccount();

                twitter.UpdateDatetime = DateTime.Now;
                twitter.AccessToken = model.AccessToken;
                twitter.AccessTokenSecret = model.AccessTokenSecret;
                twitter.AppName = model.AppName;
                twitter.ConsumerSecret = model.ConsumerSecret;
                twitter.ConsumerKey = model.ConsumerKey;
                twitter.Enable = model.Enable;
                twitter.TwitterAccountId = twitter.TwitterAccountId;

                entities.TwitterAccounts.Update(twitter);
                entities.SaveChanges();
            }

        }

        public TwitterModel GetTwitterAccountById(int id)
        {
            try
            {
                TwitterModel twitterObj = new TwitterModel();

                using (MissingPersonAwarenessContext entities = new MissingPersonAwarenessContext())
                {
                    twitterObj = (from x in entities.TwitterAccounts
                                  where x.TwitterAccountId == id
                                  select new TwitterModel
                                  {
                                      TwitterAccountId = x.TwitterAccountId,
                                      ConsumerKey = x.ConsumerKey,
                                      ConsumerSecret = x.ConsumerSecret,
                                      AccessToken = x.AccessToken,
                                      AccessTokenSecret = x.AccessTokenSecret,
                                      AppName = x.AppName,
                                      Enable = x.Enable

                                  }).FirstOrDefault();
                }

                return twitterObj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
