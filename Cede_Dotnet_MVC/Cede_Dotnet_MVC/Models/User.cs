using Cede_Dotnet_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.Models
{
    public class User
    {        
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nit { get; set; }

        public NitType NitType { get; set; }

        public DateTime NitDate { get; set; }

        [MaxLength(100)]
        public string Contract { get; set; }

        public DateTime BirthDay { get; set; }

        public UserStatus UserStatus { get; set; }

        public Genre Genre { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        //public virtual ICollection<Appointment> Appointments { get; set; }
    }
}