using Cede_Dotnet_MVC.Services;
using Cede_Dotnet_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidateUser()
        {
            return View(new UserValidation());
        }

        [HttpPost]
        public ActionResult ValidateUser(UserValidation userValidation)
        {
            UserService userService = new UserService();

            userService.GetUserByNit(userValidation.Nit);

            return View(new UserValidation());
        }
    }
}