using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace MissingPersonWebApp.Models
{
    public class MissingPersonModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Missing date is required")]
        public DateTime MissingDate { get; set; }

        public Nullable<Boolean> Found = false;
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDatetime { get; set; }

        [Required(ErrorMessage = "Please choose image")]
        [Display(Name = "Choose Image")]
        public IFormFile File { get; set; }

        public bool PublishonFacebook { get; set; }

        public bool PublishonTwitter { get; set; }

        public int FacebookAccountId { get; set; }

        public int TwitterAccountId { get; set; }

        public string TwitterText { get; set; }
        public string TwitterPostId { get; set; }
        public string FacebookText { get; set; }
        public string FacebookPostId { get; set; }

    }
}
