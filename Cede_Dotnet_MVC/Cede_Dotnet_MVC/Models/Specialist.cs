using Cede_Dotnet_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Models
{
    public class Specialist
    {        
        public Guid SpecialistId { get; set; }
        
        public string Name { get; set; }
        public string LastName { get; set; }

        public Specialty Specialty { get; set; }
       
        public string Phone { get; set; }
        
        public string Phone2 { get; set; }
      
        public string Email { get; set; }

        public SpecialistStatus SpecialistStatus { get; set; }

    }
}