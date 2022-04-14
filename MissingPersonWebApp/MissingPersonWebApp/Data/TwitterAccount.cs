using System;
using System.Collections.Generic;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class TwitterAccount
    {
        public int TwitterAccountId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string AppName { get; set; }
        public bool Enable { get; set; }
    }
}
