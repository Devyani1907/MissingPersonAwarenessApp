using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MissingPersonWebApp.Models
{
    public class TwitterModel
    {
        public int TwitterAccountId { get; set; }

        [Required(ErrorMessage = "Consumer Key is required")]
        public string ConsumerKey { get; set; }

        [Required(ErrorMessage = "Consumer Secret is required")]
        public string ConsumerSecret { get; set; }

        [Required(ErrorMessage = "Access Token is required")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "Access Token Secret is required")]
        public string AccessTokenSecret { get; set; }

        [Required(ErrorMessage = "App Name is required")]
        public string AppName { get; set; }

        public bool Enable { get; set; }
    }
}
