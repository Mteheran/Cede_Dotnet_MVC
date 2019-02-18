using Cede_Dotnet_MVC.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cede_Dotnet_MVC.Models
{
    public class User
    {        
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Identificación")]
        public string Nit { get; set; }

        [Display(Name = "Tipo Identificación")]
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