using Cede_Dotnet_MVC.Models;
using System.Threading.Tasks;

namespace Cede_Dotnet_MVC.Services.Contract
{
    public interface IAppointmentService
    {
        Task<Appointment> SaveAppointment(Appointment appointment);
    }
}