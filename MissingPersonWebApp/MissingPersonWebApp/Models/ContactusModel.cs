﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MissingPersonWebApp.Models
{
    public class ContactusModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNo is required")]
        [StringLength(11, ErrorMessage = "Please provide correct phone number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, ErrorMessage = "Maximum allowed word is 500")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
    }
}
