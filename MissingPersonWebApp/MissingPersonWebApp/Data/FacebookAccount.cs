using System;
using System.Collections.Generic;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class FacebookAccount
    {
        public int FacebookAccountId { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppSecret { get; set; }
        public string PageAccessToken { get; set; }
        public bool Enable { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
    }
}
