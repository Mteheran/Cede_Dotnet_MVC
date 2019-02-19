using Cede_Dotnet_MVC.Models.Enums;

namespace Cede_Dotnet_MVC.Helpers
{
    public static class SpecialityHelperString
    {
        public static string GetSpecialityLabel(Specialty specialty)
        {
            switch (specialty)
            {
                case Specialty.General:
                    return "Medico general";
                case Specialty.Odontology:
                    return "Odontologo";
                case Specialty.Physiotherapy:
                    return "Fisioterapeuta";
                case Specialty.Nutritionist:
                    return "Nutricionista";
                case Specialty.Ophthalmology:
                    return "Oftalmólogo";
                default:
                    specialty.ToString();
                    break;
            }

            return "";
        }
    }  
}