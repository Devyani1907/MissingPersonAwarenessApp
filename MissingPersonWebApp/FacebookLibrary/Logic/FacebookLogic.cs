using Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FacebookLibrary.Logic
{
    public class FacebookLogic
    {
        /// <summary>
        /// This method is used to post image and message on the facebook page
        /// </summary>
        /// <param name="pageAccessToken">facebook page access token</param>
        /// <param name="appId">facebook app id</param>
        /// <param name="appSecret">facebook app secret</param>
        /// <param name="imagePath">path of the image</param>
        /// <param name="message">facebook message</param>
        /// <returns>facebook post id</returns>
        public string PostImage(string pageAccessToken, string appId, string appSecret, string imagePath, string message)
        {
            try
            {
                var client = new FacebookClient(pageAccessToken);
                client.AppId = appId;
                client.AppSecret = appSecret;
                client.AccessToken = pageAccessToken;
                string postId = string.Empty;

                using (var file = new FacebookMediaStream
                {
                    ContentType = "image/jpeg",
                    FileName = Path.GetFileName(imagePath)
                }.SetValue(System.IO.File.OpenRead(imagePath)))
                {
                    dynamic result = client.Post("me/photos",
                    new { message = message, file });

                    postId = result.post_id;
                }

                return postId;
            }
            catch (FacebookOAuthException ex)
            {
                // oauth exception occurred
                return null;
            }
            catch (FacebookApiLimitException ex)
            {
                // api limit exception occurred.
                return null;
            }
            catch (FacebookApiException ex)
            {
                // other general facebook api exception
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
         
        }
    }
}