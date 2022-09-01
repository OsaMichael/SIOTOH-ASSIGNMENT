using Ninject.Modules;
using Ninject.Web.Common;
using SiotohBlog.Interface;
using SiotohBlog.Models;
using SiotohBlog.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiotohBlog
{
    public class Binders : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind<DbContext>().ToSelf().InRequestScope();
            Kernel.Bind<DbContext>().To<ApplicationDbContext>().InRequestScope();

            Bind<IBlogRepo>().To<BlogRepo>().InRequestScope();
            Bind<IAccountManager>().To<AccountManager>().InRequestScope();
            
        }
    }
}