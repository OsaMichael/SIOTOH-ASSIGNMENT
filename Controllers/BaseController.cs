using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SiotohBlog.Controllers.Common.Enum;

namespace SiotohBlog.Controllers
{
    public class BaseController : Controller
    {
        public void Alert(string message, dynamic content, NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "','" + content + "', '" + message + "','" + notificationType + "')" + " </script>";
            TempData["notification"] = msg;

        }
    }
}