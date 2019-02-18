using Cede_Dotnet_MVC.Models;
using Cede_Dotnet_MVC.Services.Contract;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC.Controllers
{
    public class AppointmentController : Controller
    {
        ISpecialistService specialistService;
        IDisponibilityService disponibilityService;
        IAppointmentService appointmentService;

        public AppointmentController(ISpecialistService specialistservice, IDisponibilityService disponibilityservice, IAppointmentService appointmentservice)
        {
            specialistService = specialistservice;
            disponibilityService = disponibilityservice;
            appointmentService = appointmentservice;
        }

        [HttpPost]
        public async Task<ActionResult> RequestAppointment(User user)
        {
            Appointment appointment = new Appointment();
            appointment.UserId = user.UserId;

            ViewBag.Specialist = await specialistService.GetSpecialist();
            ViewBag.SpecialistList = new SelectList(await specialistService.GetSpecialist(), "SpecialistId", "Name ");
            ViewBag.Disponibility = await disponibilityService.GetDisponibility();

            return View(appointment);
        }

        [HttpGet]
        public async Task<ActionResult> RequestAppointmentOk(string Id)
        {
            ViewData["ConfirmMessage"] = "Su cita ha sido almacenada. Código: " + Id;

            return View("RequestAppointment", null);
        }

        [HttpPost]
        public async Task<ActionResult> SaveAppointment(Appointment appointment)
        {
            appointment.AppointmentStatus = Models.Enums.AppointmentStatus.Scheduled;
            appointment.AppointmentDate = ChangeTime(appointment.AppointmentDate, int.Parse(Request["Hour"]));

            ViewBag.Specialist = await specialistService.GetSpecialist();
            ViewBag.SpecialistList = new SelectList(await specialistService.GetSpecialist(), "SpecialistId", "Name ");
            ViewBag.Disponibility = await disponibilityService.GetDisponibility();

            var appointmentsave = await appointmentService.SaveAppointment(appointment);

            if (appointmentsave == null)
            {
                ModelState.AddModelError("","No fue posible agendar la cita intente de nuevo");

                return View("RequestAppointment", appointment);
            }                      

            return RedirectToAction("RequestAppointmentOk", new {Id = appointmentsave.Code });
        }

        private DateTime ChangeTime(DateTime dateTime, int hours)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,0,0);
        }
    }
}