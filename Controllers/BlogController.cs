using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using SiotohBlog.Interface;
using SiotohBlog.Models;
using SiotohBlog.Repository;
using SiotohBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static SiotohBlog.Controllers.Common.Enum;

namespace SiotohBlog.Controllers
{
    public class BlogController : BaseController
    {

        private readonly IBlogRepo _blog;

        public BlogController(IBlogRepo blog)
        {
            _blog = blog;
        }
        // GET: Blog
        public ActionResult Index()
        {
            //var list = _blog.AllNews().ToList();
            return View();
        }
        public ActionResult RgisteredUser()
        {
            var loginUser = User.Identity.GetUserName();
               var ressult = _blog.UserDetails(loginUser);

            return View(ressult);
        }

        [HttpGet]
        public ActionResult UploadBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBlog(BlogModel blog)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("value cannot be null");
            }
            blog.CreatedBy = User.Identity.GetUserName();
            var result = _blog.UploadBlog(blog);
            if (result)
            {
                TempData["message"] = string.Format("{0} has been uploaded.", blog.Title);

                dynamic transRef = TempData["Message"];

                Alert("success", transRef, NotificationType.success);

                return RedirectToAction("UploadBlog");
            }
            return View();
        }

        public ActionResult ReadMore(int id)
        {
            var read = _blog.Details(id);
            return View(read);
        }

        [HttpGet]
        public ActionResult GetBlog()
        {

            List<BlogModel> posts = null;

            using (var client = new HttpClient())
            {
                var url = new Uri("https://mocki.io/v1/d33691f7-1eb5-45aa9642-8d538f6c5ebd");
                //HTTP GET
                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    posts = JsonConvert.DeserializeObject<List<BlogModel>>(result.Result);

                    // get and save to datase 
                }
                // return View(posts);

            }
            return View(posts);

        }
        public ActionResult UserList()
        {
            var u = _blog.UserList();

            return View(u);
        }

    }

}