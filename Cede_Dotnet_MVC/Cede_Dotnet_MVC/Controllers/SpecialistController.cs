using Cede_Dotnet_MVC.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC.Controllers
{
    public class SpecialistController : Controller
    {
        ISpecialistService specialistService;

        public SpecialistController(ISpecialistService specialistservice)
        {
            specialistService = specialistservice;
        }

        // GET: Specialist
        public async Task<ActionResult> Index()
        {
            return View("Index", await specialistService.GetSpecialist());
        }
    }
}