using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Models
{
    public class Disponibility
    {
        public Guid DisponibilityId { get; set; }
        public short Hour { get; set; }

        public Guid SpecialistId { get; set; }

        public Specialist Specialist { get; set; }
    }
}