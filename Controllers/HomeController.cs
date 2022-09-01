using SiotohBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiotohBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepo _blog;
        public HomeController(IBlogRepo blog )
        {
            _blog = blog;
        }
        public ActionResult Index(int? page, string searchBy, string search)
        {
            var results = _blog.AllNews().ToList();
            if (searchBy == "PublicationDate")
            {
                var returnResult = results.Where(x=>x.PublicationDate.ToString("dd/MM/yyyy").Contains(search)).ToList();
               // var returnResult = results.Result.Where(x => x.StaffName.ToLower().Contains(search.ToLower())).ToPagedList(page ?? 1, 12);
                return View(returnResult);
             }
            if (results != null)
            {
                return View(results.OrderByDescending(c => c.PublicationDate));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occure");
                return View(results);
            }

           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}