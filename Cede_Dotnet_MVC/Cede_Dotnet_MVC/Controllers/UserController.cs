using Cede_Dotnet_MVC.Services;
using Cede_Dotnet_MVC.Services.Contract;
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
        public IUserService userService {get;set;}

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidateUser()
        {
            return View(new UserValidation());
        }

        public ActionResult InfoUser(string id)
        {
            var user = userService.GetUserByUserId(id);

            if (user?.UserId.ToString() != string.Empty)
            {
                return View(user);
            }

            ModelState.AddModelError("InvalidUser", "Usuario no encontrado en el sistema");

            return View(new UserValidation());
        }

        [HttpPost]
        public ActionResult ValidateUser(UserValidation userValidation)
        {
            if (!ModelState.IsValid) return View(new UserValidation());

            string UserId = userService.ValidateUserByNitAndNitDate(userValidation.Nit, userValidation.NitDate);

            if (UserId!=string.Empty)
            {
                return RedirectToAction("InfoUser", "User", new { id = UserId });
            }
                        
            ModelState.AddModelError("InvalidUser", "Usuario no encontrado en el sistema");

            return View(new UserValidation());
        }
    }
}