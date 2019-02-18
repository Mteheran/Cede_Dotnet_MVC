using System.ComponentModel.DataAnnotations;

namespace Cede_Dotnet_MVC.Models.Enums
{
    public enum Specialty
    {
        [Display(Name = "General")]
        General,
        [Display(Name = "Odontologia")]
        Odontology,
        [Display(Name = "Fisioterapia")]
        Physiotherapy,
        [Display(Name = "Nutricionista")]
        Nutritionist,
        [Display(Name = "Oftalmologia")]
        Ophthalmology
    }
}
