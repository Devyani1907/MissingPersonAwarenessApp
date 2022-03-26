using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
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
        public Nullable<DateTime> MissingDate { get; set; }

        public Nullable<Boolean> Found = false; 
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDatetime { get; set; }

        [Required(ErrorMessage = "Please upload image")]
        public HttpPostedFileBase File { get; set; }

    }
}