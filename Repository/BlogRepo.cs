using Microsoft.AspNet.Identity;
using SiotohBlog.Models;
using SiotohBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SiotohBlog.Repository
{
    public class BlogRepo : IBlogRepo
    {
        private readonly ApplicationDbContext _context;
        public BlogRepo()
        {
            _context = new ApplicationDbContext();
        }

        public bool UploadBlog(BlogModel model)
        {
            var isexist = _context.Blogs.Where(x => x.PublicationDate == model.PublicationDate).FirstOrDefault();
            if (isexist != null) throw new Exception("already exist");
            var blog = new Blog
            {
                Description = model.Description,
                PublicationDate = model.PublicationDate,
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                CreatedBy = model.CreatedBy

            };

            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return true;
        }

        public List<BlogModel> AllNews()
        {
            var resp = new List<BlogModel>();
            try
            {
            var entities = _context.Blogs.ToList();

            foreach(var itm in entities)
            {
                var bbb = new BlogModel();
                bbb.Description = itm.Description;
                bbb.PublicationDate = itm.PublicationDate;
                bbb.Title = itm.Title;
                    bbb.ShortDescription = itm.ShortDescription;
                    bbb.Id = itm.Id;
                resp.Add(bbb);
            }

            }
            catch(Exception xx)
            {
                throw xx;
            }
            

            return resp;
        }

        public List<BlogModel> UserDetails(string loginUser)
        {
            var resp = new List<BlogModel>();
            try
            {
                var entities = _context.Blogs.Where(x => x.CreatedBy == loginUser).ToList();
     
                    foreach (var itm in entities)
                    {
                        var user = new BlogModel();
                        user.Description = itm.Description;
                        user.PublicationDate = itm.PublicationDate;
                        user.ShortDescription = itm.ShortDescription;
                        user.Title = itm.Title;
                        user.Id = itm.Id;
                        resp.Add(user);
                    } 

            }
            catch (Exception xx)
            {
                throw xx;
            }
            return resp;

        }

        public BlogModel Details(int id)
        {
            var read = new BlogModel();
            try
            {
                var isExist = _context.Blogs.Find(id);
                if(isExist != null)
                {
                    var entity = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
                    if (entity == null) throw new Exception("user id not found");

                    read = new BlogModel
                    {
                        Description = entity.Description,
                        Title = entity.Title,
                        PublicationDate = entity.PublicationDate,
                        ShortDescription = entity.ShortDescription,
                        Id = entity.Id
                    };
                }
                else
                {
                    throw new Exception("user detail not found");
                }

            }
            catch (Exception xx)
            {
                throw xx;
            }
            return read;

        }


        public List<UserViewModel> UserList()
        {
            var usersModel = new List<UserViewModel>();
            var results = _context.Users.ToList();
            foreach (var user in results)
            {
                var u = new UserViewModel();
                u.Email = user.Email;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                usersModel.Add(u);

            }
            return usersModel;
        }

    }
}