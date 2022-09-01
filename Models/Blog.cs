using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiotohBlog.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        //public User User { get; set; }
        //public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string ShortDescription { get; set; }
    }
}