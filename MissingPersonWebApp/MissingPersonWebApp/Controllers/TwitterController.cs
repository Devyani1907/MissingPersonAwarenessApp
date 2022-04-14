using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi; 
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using MissingPersonWebApp.Models;
using MissingPersonWebApp.Logic;

namespace MissingPersonWebApp.Controllers
{
    public class TwitterController : Controller
    {
        public TwitterController()
        {
           
        }

        /// <summary>
        /// This method tweets missing person image and information on the Twitter
        /// </summary>
        /// <param name="model">missing person data</param>
        /// <returns></returns>
        public async Task PostImage(MissingPersonModel model)
        {
            try
            {
                TwitterLogic twitterObj = new TwitterLogic();
                TwitterModel twitterAccountData = twitterObj.GetTwitterAccountDetail();
                ManageMissingPersonLogic logic = new ManageMissingPersonLogic();
                model = logic.GetMissingPersonDetailById(model.Id);

                string ConsumerKey = twitterAccountData.ConsumerKey; 
                string ConsumerSecret = twitterAccountData.ConsumerSecret; 
                string TokenKey = twitterAccountData.AccessToken; 
                string TokenSecretKey = twitterAccountData.AccessTokenSecret; 
                byte[] ImageBytes = System.IO.File.ReadAllBytes(model.ImagePath + model.ImageName);

                string message = "On " + model.MissingDate.ToShortDateString() + ", one person was registered as missing person. Below are the details:" + Environment.NewLine +
                    "Name: " + model.FirstName + " " + model.LastName + Environment.NewLine +
                    "Age: " + model.Age;

                TwitterClient client = new TwitterClient(ConsumerKey, ConsumerSecret, TokenKey, TokenSecretKey);
                IMedia media = await client.Upload.UploadTweetImageAsync(ImageBytes);
                ITweet tweet = await client.Tweets.PublishTweetAsync(new PublishTweetParameters(message) { Medias = { media } });

                if(model.Id > 0)
                {
                    model.TwitterAccountId = twitterAccountData.TwitterAccountId;
                    model.TwitterPostId = tweet.Id == 0 ? null : tweet.Id.ToString();
                    model.TwitterText = tweet.Text == string.Empty ? null : tweet.Text;
                    logic.UpdateTwitterPostId(model);
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
