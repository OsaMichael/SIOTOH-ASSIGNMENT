using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiotohBlog.ViewModel
{
    public class BlogExternalModel
    {
        public string Title { get; set; }
    
        [Display(Name = "Long Description")]
        public string Description { get; set; }
   
        [Display(Name = "Publication  Date ")]
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        [Display(Name = " Brief Description")]
        public string ShortDescription { get; set; }
    }
}