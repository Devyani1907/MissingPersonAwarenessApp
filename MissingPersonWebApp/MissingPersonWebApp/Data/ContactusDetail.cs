using System;
using System.Collections.Generic;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class ContactusDetail
    {
        public int Contactid { get; set; }
        public string EmailId { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedDatetime { get; set; }
    }
}
