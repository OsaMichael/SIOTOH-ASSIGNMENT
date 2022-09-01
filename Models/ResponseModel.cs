using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiotohBlog.Models
{
    public class ResponseModel
    {
        public string Data { get; set; }
        public bool isSuccessful { get; set; }
        public string message { get; set; }
    }
}