using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC.Filters
{
    public class UserErrorHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            StreamWriter str = new StreamWriter(@"D:\log.log");

            str.WriteLine(filterContext.Exception.Message);

            str.Close();
        }
    }
}