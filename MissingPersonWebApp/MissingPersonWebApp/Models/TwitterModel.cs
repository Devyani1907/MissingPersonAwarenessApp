using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Models
{
    public class TwitterModel
    {
        public int TwitterAccountId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public bool Enable { get; set; }
    }
}
