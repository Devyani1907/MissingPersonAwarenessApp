using System;
using System.Collections.Generic;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class MissingPersonDatum
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public DateTime MissingDate { get; set; }
        public bool? Found { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public int? FacebookAccountId { get; set; }
        public int? TwitterAccountId { get; set; }
        public bool IsLiveOnFacebook { get; set; }
        public bool IsLiveOnTwitter { get; set; }
        public string TwitterPostId { get; set; }
        public string TwitterText { get; set; }
        public string FacebookPostId { get; set; }
        public string FacebookText { get; set; }
    }
}
