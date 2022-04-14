﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonWebApp.Models
{
    public class FacebookModel
    {
        public int FacebookAccountId { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppSecret { get; set; }
        public string PageAccessToken { get; set; }
        public bool Enable { get; set; }

    }
}
