using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MissingPersonWebApp.Models
{
    public class FacebookModel
    {
        public int FacebookAccountId { get; set; }

        [Required(ErrorMessage = "App Id is required")]
        public string AppId { get; set; }

        [Required(ErrorMessage = "App Name is required")]
        public string AppName { get; set; }

        [Required(ErrorMessage = "App Secret is required")]
        public string AppSecret { get; set; }

        [Required(ErrorMessage = "Page Access Token is required")]
        public string PageAccessToken { get; set; }


        public bool Enable { get; set; }

    }
}
