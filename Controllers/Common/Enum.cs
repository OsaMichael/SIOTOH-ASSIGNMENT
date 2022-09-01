using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiotohBlog.Controllers.Common
{
    public class Enum
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }
        public enum MessageType
        {
            ErrorMessage,
            SuccessMessage,
            InfoMessage,
            Warning,
        }
    }
}