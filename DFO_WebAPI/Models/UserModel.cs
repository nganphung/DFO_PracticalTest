using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DFO_WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        [MaxLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
    }
}