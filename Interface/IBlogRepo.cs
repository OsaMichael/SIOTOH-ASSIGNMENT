using SiotohBlog.Models;
using SiotohBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiotohBlog.Repository
{
    public interface IBlogRepo
    {
        bool UploadBlog(BlogModel model);
        List<BlogModel> AllNews();
        List<BlogModel> UserDetails(string loginUser);
        BlogModel Details(int id);
        List<UserViewModel> UserList();
    }
}