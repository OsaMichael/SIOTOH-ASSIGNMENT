using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiotohBlog.ViewModel
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Long Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Publication  Date ")]
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string BUrl { get; set; }
        [Display(Name = " Brief Description")]
        public string ShortDescription { get; set; }


    }
}