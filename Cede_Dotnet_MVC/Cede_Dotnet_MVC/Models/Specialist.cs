using Cede_Dotnet_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Models
{
    public class Specialist
    {        
        public Guid SpecialistId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Especialidad")]
        public Specialty Specialty { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }
        
        public string Phone2 { get; set; }
      
        public string Email { get; set; }

        public SpecialistStatus SpecialistStatus { get; set; }

    }
}