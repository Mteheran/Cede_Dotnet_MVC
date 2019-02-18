using Cede_Dotnet_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Models
{
    public class Appointment
    {       
        public Guid AppointmentId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Especialista")]
        public Guid SpecialistId { get; set; }

        [Display(Name = "Especialista")]
        public Specialist Specialist { get; set; }

        [Display(Name = "Fecha")]
        public DateTime AppointmentDate { get; set; }

        public string Code { get; set; } = "AP" + DateTime.Now.Date.Millisecond;

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}