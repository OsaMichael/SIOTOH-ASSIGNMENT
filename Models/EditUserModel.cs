using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiotohBlog.Models
{
    public class EditUserModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }

        public string NewEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}