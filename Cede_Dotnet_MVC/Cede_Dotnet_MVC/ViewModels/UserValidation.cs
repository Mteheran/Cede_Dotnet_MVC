using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cede_Dotnet_MVC.ViewModels
{
    public class UserValidation
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="La cedula es requerida")]
        [Display(Name = "Cedula")]
        [MinLength(5, ErrorMessage ="La cedula es de minimo 5 caracteres")]
        public string Nit { get; set; }

        [Display(Name = "Fecha de Expedición")]
        [DataType(DataType.DateTime)]
        public DateTime NitDate { get; set; }
    }
}